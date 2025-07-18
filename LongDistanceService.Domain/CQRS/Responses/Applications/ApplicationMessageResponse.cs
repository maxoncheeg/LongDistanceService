﻿using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Applications;

namespace LongDistanceService.Domain.CQRS.Responses.Applications;

public record ApplicationMessageResponse(
    int Id,
    int ApplicationId,
    int UserId,
    int? AnsweredAt,
    string Text,
    DateTime Timestamp) : IApplicationMessage;