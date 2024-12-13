﻿namespace WebApiDapper.Models;

public class Car
{
    public int? Id { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public int? Year { get; set; }
    public double? PricePerDay { get; set; }
}