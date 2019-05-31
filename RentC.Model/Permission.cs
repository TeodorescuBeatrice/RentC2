using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Model
{
    [Serializable]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<RolesPermission> RolesPermissions { get; set; }
    }
}
