using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Model
{
    [Serializable]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; }
        public List<RolesPermission> RolesPermissions { get; set; }
    }
}
