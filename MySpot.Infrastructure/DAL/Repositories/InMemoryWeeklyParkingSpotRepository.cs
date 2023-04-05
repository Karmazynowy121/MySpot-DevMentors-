﻿using MySpot.Application.Services;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories
{
    public class InMemoryWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
    {
        private readonly IClock _clock;
        private readonly List<WeeklyParkingSpot> _weeklyParkingSpots;
        public InMemoryWeeklyParkingSpotRepository(IClock clock)
        {
            _clock = clock;
            _weeklyParkingSpots = new List<WeeklyParkingSpot>()
    {
        new (Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
        new (Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
        new (Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
        new (Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
        new (Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5"),
    };
        }
        public Task <WeeklyParkingSpot> GetAsync(ParkingSpotId id)
            => Task.FromResult(_weeklyParkingSpots.SingleOrDefault(x => x.Id == id));
        public Task <IEnumerable<WeeklyParkingSpot>> GetAllAsync()
            => Task.FromResult(_weeklyParkingSpots.AsEnumerable());
        public Task AddAsync(WeeklyParkingSpot weeklyparkingSpot)
        {
            _weeklyParkingSpots.Add(weeklyparkingSpot);
            return Task.CompletedTask;
        }


        public Task DeleteAsync(WeeklyParkingSpot weeklyparkingSpot)
        {
            _weeklyParkingSpots.Remove(weeklyparkingSpot);
            return Task.CompletedTask;
        }




        public Task UpdateAsync(WeeklyParkingSpot weeklyparkingSpot)
           =>  Task.CompletedTask;
        

    }
}