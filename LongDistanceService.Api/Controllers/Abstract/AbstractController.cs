using System.Diagnostics.Metrics;
using LongDistanceService.Api.Models.Responses;
using LongDistanceService.Api.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LongDistanceService.Api.Controllers.Abstract;

[ApiController]
public abstract class AbstractController : Controller
{
    // todo: обзавестить логгером
    private readonly Meter _meter = new Meter("ControllerMeter");

    private readonly Counter<long> _responseBodySizeCounter;

    protected AbstractController()
    {
        _responseBodySizeCounter = _meter.CreateCounter<long>(
            "controller_response_body_size",
            unit: "bytes",
            description: "Size of outcoming HTTP response bodies in bytes"
        );
    }

    protected ActionResult BaseResponse(int statusCode, object? data = null, string message = "")
    {
        ApiResponse response = new(statusCode, data, message);

        _responseBodySizeCounter.Add(JsonConvert.SerializeObject(data).Length,
            new KeyValuePair<string, object?>("route", this.Request.Path.Value));
        return Ok(response);
    }

    protected RequestValidation ValidateGetRequestPagination(int skip, int take)
    {
        var validation = new RequestValidation { Result = true };

        if (skip < 0 || take < 0)
        {
            validation.Result = false;
            validation.Code = StatusCodes.Status400BadRequest;

            if (skip < 0)
                validation.Message = "Значение 'skip' должно быть больше или равно 0";

            if (take < 0)
                validation.Message = "Значение 'take' должно быть больше или равно 0";
        }


        return validation;
    }
}