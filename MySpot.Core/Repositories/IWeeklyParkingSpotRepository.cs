using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;


namespace MySpot.Core.Repositories
{
    public interface IWeeklyParkingSpotRepository
    {
        Task <WeeklyParkingSpot> GetAsync(ParkingSpotId id);
        Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) => throw new NotImplementedException();
        Task <IEnumerable<WeeklyParkingSpot>> GetAllAsync();
        Task AddAsync(WeeklyParkingSpot weeklyparkingSpot);
        Task UpdateAsync(WeeklyParkingSpot weeklyparkingSpot);
        Task DeleteAsync(WeeklyParkingSpot weeklyparkingSpot);
    }

   
}
