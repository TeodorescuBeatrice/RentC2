using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Model
{
    [Serializable]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; } //fk
    }
}
