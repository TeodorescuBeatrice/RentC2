using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentC.Model;

namespace RentC.Repository
{
    public interface IReservationRepository
    {
        Reservation GetReservation(int CarId, int CustomerId);
        List<Reservation> GetReservations();
        void AddReservation(Reservation res);
        void UpdateReservation(Reservation res);
        void DeleteReservation(int CarId, int CustomerId);
    }
}
