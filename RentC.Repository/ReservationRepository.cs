using System.Collections.Generic;
using System.Linq;
using RentC.Model;

namespace RentC.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private RentCDb _dbContext;
        public ReservationRepository()
        {
            _dbContext = new RentCDb();    
        }

        public void AddReservation(Reservation res)
        {
            _dbContext.Reservations.Add(res);
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(int CarId, int CustomerId)
        {
            var res = _dbContext.Reservations.SingleOrDefault(r => ((r.CarID == CarId) && (r.CostumerID == CustomerId)));
            _dbContext.Reservations.Remove(res);
            _dbContext.SaveChanges();
        }

        public Reservation GetReservation(int CarId, int CustomerId)
        {

            return _dbContext.Reservations.SingleOrDefault(r => ((r.CarID == CarId) && (r.CostumerID == CustomerId)));
        }

        public List<Reservation> GetReservations()
        { 

            return _dbContext.Reservations.Select(r => r).ToList();
        }

        public void UpdateReservation(Reservation res)
        {
            _dbContext.Reservations.Add(res);
            _dbContext.Entry(res).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
