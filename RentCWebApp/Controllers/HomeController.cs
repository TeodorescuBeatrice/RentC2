using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentC.Model;
using RentC.Repository;
using RentCWebApp.Models;
namespace RentCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IReservationRepository _reservationRepository = new ReservationRepository();
        private RentCDb _dbContext = new RentCDb();
        public HomeController()
        {
            // _reservationRepository = reservationRepository;
        }
        public ActionResult Index()
        {
            //var model = _reservationRepository.GetReservations();
            var model = _dbContext.Reservations.Select(r =>
            new ReservationViewModel
            {
                ReservStatsID = r.ReservStatsID,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Location = r.Location,
                CouponCode = r.CouponCode
            }).ToList();
         //   ViewBag.Message = reservations.First().CouponCode;
            return View(model);
            // using(RentCDb _context = new RentCDb())
            // return Json(_reservationRepository.GetReservations(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application is for OSF Academy.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reservations()
        {
            return View();
        }
    }
}