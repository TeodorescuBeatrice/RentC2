using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Model
{
    [Serializable]
    public class Customer
    {
        [Key]
        public int CostumerID { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
