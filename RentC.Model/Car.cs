using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RentC.Model
{
    [Serializable]
    [DataContract]
    public class Car
    {
        [Key]

        public int CarID { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public decimal PricePerDay { get; set; }
        [DataMember]
        public List<Reservation> Reservations { get; set; }
    }
}
