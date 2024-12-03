using System.Drawing;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using MediatR;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace LongDistanceService.Domain.Services;

public class WordSqlConverter(IMediator mediator) : IWordSqlConverter
{
    public async Task<Stream?> ConvertTableToWordAsync(string tableName)
    {
        // todo: обезопасить!
        var sqlTable =
            await mediator.Send(new SelectSqlRequest("select * from " + tableName));

        if (sqlTable.Message != string.Empty) return null;
        
        Document doc = new Document();
        Section section = doc.AddSection();
        section.PageSetup.Orientation = PageOrientation.Landscape;
        Table table = section.AddTable(true);
        table.ResetCells(sqlTable.Rows.Count + 1, sqlTable.Headers.Count);

        TableRow headerRow = table.Rows[0];
        headerRow.IsHeader = true;
        headerRow.Height = 23;
        headerRow.RowFormat.BackColor = Color.LightSeaGreen;
        for (int i = 0; i < sqlTable.Headers.Count; i++)
        {
            Paragraph paragraph = headerRow.Cells[i].AddParagraph();
            TextRange textRange = paragraph.AppendText(sqlTable.Headers[i]);
            
            headerRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
            
            paragraph.Format.HorizontalAlignment = HorizontalAlignment.Center;
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.FontSize = 12;
            textRange.CharacterFormat.Bold = true;
        }

        for (int r = 0; r < sqlTable.Rows.Count; r++)
        {
            TableRow dataRow = table.Rows[r + 1];
            dataRow.Height = 20;
            
            for (int c = 0; c < sqlTable.Rows[r].Count; c++)
            {   
                Paragraph paragraph = dataRow.Cells[c].AddParagraph();
                TextRange textRange = paragraph.AppendText(sqlTable.Rows[r][c]);
                
                dataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                
                paragraph.Format.HorizontalAlignment = HorizontalAlignment.Center;
                textRange.CharacterFormat.FontName = "Calibri";
                textRange.CharacterFormat.FontSize = 11;
            }
        }

        string fileName = "WORD\\" + tableName + ".docx";
        
        doc.SaveToFile(fileName, FileFormat.Docx2016);
        FileStream stream = File.OpenRead(fileName);

        return stream;
    }
}