﻿using MySpot.Application.Services;


namespace MySpot.Tests.Unit.Shareds
{
    public class TestClock : IClock
    {
        public DateTime Current() => new(2022, 08, 11);
    }
}