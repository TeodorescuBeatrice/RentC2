using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentC.Repository;

namespace RentCWebApp.Controllers
{
    public class DataServiceController : Controller
    {
        IReservationRepository _reservationRepository;

        public DataServiceController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        // GET: DataService
        public ActionResult GetReservations()
        {
            return Json(_reservationRepository.GetReservations(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReservationById(int CarId, int CustomerId)
        {
            return Json(_reservationRepository.GetReservation(CarId, CustomerId), JsonRequestBehavior.AllowGet);
        }

        
    }
}