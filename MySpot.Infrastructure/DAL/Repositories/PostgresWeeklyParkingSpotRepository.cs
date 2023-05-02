using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Infrastructure.DAL.Repositories
{
    internal sealed class PostgresWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
    {
        private readonly MySpotDbContext _dbContext;
        public PostgresWeeklyParkingSpotRepository(MySpotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(WeeklyParkingSpot weeklyparkingSpot)
        {
            await _dbContext.AddAsync(weeklyparkingSpot);
            
        }

        public Task DeleteAsync(WeeklyParkingSpot weeklyparkingSpot)
        {
            _dbContext.Remove(weeklyparkingSpot);
            return Task.CompletedTask;
        
        }

        public Task <WeeklyParkingSpot> GetAsync(ParkingSpotId id)
            => _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week)
            => await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .Where(x => x.Week == week)
            .ToListAsync();


        public async Task <IEnumerable<WeeklyParkingSpot>> GetAllAsync()
        {
             var result = await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .ToListAsync();

            return result.AsEnumerable();
        }


        public Task UpdateAsync(WeeklyParkingSpot weeklyparkingSpot)
        {
            _dbContext.Update(weeklyparkingSpot);
            return Task.CompletedTask;
        }
    }
}
