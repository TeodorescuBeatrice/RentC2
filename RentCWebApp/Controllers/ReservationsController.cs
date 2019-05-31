using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentC.Model;
using RentC.Repository;

namespace RentCWebApp.Controllers
{
    public class ReservationsController : Controller
    {
        private RentCDb db;
        private ReservationRepository reservationRepository;
        public ReservationsController()
        {
            db = new RentCDb();
            reservationRepository = new ReservationRepository();
        }
        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = reservationRepository.GetReservations();
            reservations.ToList().ForEach(res =>
            {
                res.Car = db.Cars.Select(c => c).FirstOrDefault(c => res.CarID == c.CarID);
                res.Customer = db.Customers.Where(c => c.CostumerID == res.CostumerID).First();
                res.Coupon = db.Coupons.Where(c => c.CouponCode == res.CouponCode).First();
                res.ReservStats = db.ReservationStatuses.Where(r => r.ReservStatsID == res.ReservStatsID).First();
            }
                );
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5/2
        public ActionResult Details(int CarId, int CustomerId)
        {
            var reservations = reservationRepository.GetReservations();
            reservations.ToList().ForEach(res =>
            {
                res.Car = db.Cars.Select(c => c).FirstOrDefault(c => res.CarID == c.CarID);
                res.Customer = db.Customers.Where(c => c.CostumerID == res.CostumerID).First();
                res.Coupon = db.Coupons.Where(c => c.CouponCode == res.CouponCode).First();
                res.ReservStats = db.ReservationStatuses.Where(r => r.ReservStatsID == res.ReservStatsID).First();
            }
                );
            if (CarId == 0 || CustomerId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservation(CarId,CustomerId);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Plate");
            ViewBag.CouponCode = new SelectList(db.Coupons, "CouponCode", "CouponCode");
            ViewBag.CostumerID = new SelectList(db.Customers, "CostumerID", "Name");
            ViewBag.ReservStatsID = new SelectList(db.ReservationStatuses, "ReservStatsID", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,CostumerID,ReservStatsID,StartDate,EndDate,Location,CouponCode")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservationRepository.AddReservation(reservation);
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Plate", reservation.CarID);
            ViewBag.CouponCode = new SelectList(db.Coupons, "CouponCode", "Description", reservation.CouponCode);
            ViewBag.CostumerID = new SelectList(db.Customers, "CostumerID", "Name", reservation.CostumerID);
            ViewBag.ReservStatsID = new SelectList(db.ReservationStatuses, "ReservStatsID", "Name", reservation.ReservStatsID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5/5
        public ActionResult Edit(int CarId, int CustomerId)
        {
            if(CarId == 0 || CustomerId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservation(CarId, CustomerId);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Plate", reservation.CarID);
            ViewBag.CouponCode = new SelectList(db.Coupons, "CouponCode", "CouponCode", reservation.CouponCode);
            ViewBag.CostumerID = new SelectList(db.Customers, "CostumerID", "Name", reservation.CostumerID);
            ViewBag.ReservStatsID = new SelectList(db.ReservationStatuses, "ReservStatsID", "Name", reservation.ReservStatsID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,CostumerID,ReservStatsID,StartDate,EndDate,Location,CouponCode")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservationRepository.UpdateReservation(reservation);
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Plate", reservation.CarID);
            ViewBag.CouponCode = new SelectList(db.Coupons, "CouponCode", "Description", reservation.CouponCode);
            ViewBag.CostumerID = new SelectList(db.Customers, "CostumerID", "Name", reservation.CostumerID);
            ViewBag.ReservStatsID = new SelectList(db.ReservationStatuses, "ReservStatsID", "Name", reservation.ReservStatsID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5/5
        public ActionResult Delete(int CarId, int CustomerId)
        {
            if (CarId == 0 || CustomerId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservation(CarId, CustomerId);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int CarId, int CustomerId)
        {
            reservationRepository.DeleteReservation(CarId, CustomerId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
