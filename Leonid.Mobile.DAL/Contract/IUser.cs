using Leonid.Mobile.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonid.Mobile.DAL.Contract
{
    public interface IUser
    {
        User GetUserDetails(string userName, string password);
    }
}
