﻿namespace BookingApp.DTO;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<City>? Cities { get; set; } = null!;
}