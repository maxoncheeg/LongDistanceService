﻿using System.Diagnostics.Metrics;
using LongDistanceService.Api.Models.Responses;
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
        
        _responseBodySizeCounter.Add(JsonConvert.SerializeObject(data).Length, new KeyValuePair<string, object?>("route", this.Request.Path.Value));
        return Ok(response);
    }
}