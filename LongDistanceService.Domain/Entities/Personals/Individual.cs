﻿using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Personals;

public class Individual : AbstractPersonalEntity
{
    public string Phone { get; set; } = String.Empty;
    public string PassportSeries { get; set; } = String.Empty;
    public DateOnly PassportDate { get; set; }
    public string PassportIssued { get; set; } = String.Empty;
}