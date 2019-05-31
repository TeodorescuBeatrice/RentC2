using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCWebApp.Models
{
    public class ReservationViewModel
    {

        public Byte ReservStatsID { get; set; } //fk
 
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }


        public string CouponCode { get; set; } //fk
    }
}