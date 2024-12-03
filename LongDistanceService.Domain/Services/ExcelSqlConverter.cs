using System.Data;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using MediatR;
using Spire.Xls;

namespace LongDistanceService.Domain.Services;

public class ExcelSqlConverter(IMediator mediator) : IExcelSqlConverter
{
    public async Task<Stream?> ConvertTableToExcelAsync(string tableName)
    {
        // todo: обезопасить!
        var table =
            await mediator.Send(new SelectSqlRequest("select * from " + tableName));

        if (table.Message != string.Empty) return null;

        Workbook workbook = new Workbook();

        //Получение первой рабочей страницы
        Worksheet worksheet = workbook.Worksheets[0];

        //Создание объекта DataTable
        DataTable dataTable = new DataTable();
        for (int i = 0; i < table.Headers.Count; i++)
        {
            dataTable.Columns.Add(table.Headers[i], table.HeaderTypes[i]);
        }

        foreach (var row in table.Rows)
        {
            DataRow dataRow = dataTable.NewRow();
            for (int i = 0; i < row.Count; i++)
                dataRow[i] = row[i];
            dataTable.Rows.Add(dataRow);
        }

        //Запись DataTable в таблицу
        worksheet.InsertDataTable(dataTable, true, 1, 1, true);

        //Автоматическое подгонка ширины столбцов
        worksheet.AllocatedRange.AutoFitColumns();

        //Применение стиля к первой строке
        CellStyle style = workbook.Styles.Add("newStyle");
        style.Font.IsBold = true;
        worksheet.Range[1, 1, 1, 3].Style = style;

        workbook.DocumentProperties.Author = "Long Distance Service";
        workbook.DocumentProperties.Title = "Table" + tableName;
        var filename = "EXCEL\\" + tableName + ".xlsm";
        
        workbook.SaveToFile(filename, ExcelVersion.Version2016);
        FileStream stream = File.OpenRead(filename);

        return stream;
    }
}