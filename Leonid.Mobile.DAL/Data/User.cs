using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonid.Mobile.DAL.Data
{
    public class User
    {
        public double UserId { get; set; }
        public double RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DTCreated { get; set; }
        public DateTime? DTUpdated { get; set; }
    }
}
