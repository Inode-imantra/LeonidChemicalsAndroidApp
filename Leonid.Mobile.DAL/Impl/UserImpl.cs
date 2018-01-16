using Leonid.Mobile.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leonid.Mobile.DAL.Data;
using P3Net.Data;
using P3Net.Data.Common;
using System.Data;

namespace Leonid.Mobile.DAL.Impl
{
    public class UserImpl : IUser
    {
        public User GetUserDetails(string userName, string password)
        {
            User user = null;
            try
            {
                StoredProcedure coreCustomerProcedure = new StoredProcedure("usp_GetUserDetails");

                coreCustomerProcedure.WithParameters(InputParameter.Named("UserName").WithValue(userName));
                coreCustomerProcedure.WithParameters(InputParameter.Named("Password").WithValue(password));

                using (IDataReader datareader = DataConnectionHelper.GetConnectionManager().ExecuteReader(coreCustomerProcedure))
                {
                    while (datareader.Read())
                    {
                        user = new User();

                        user.UserId = datareader.GetInt64OrDefault("UserID");
                        user.UserName = datareader.GetStringOrDefault("Name");
                        user.Email = datareader.GetStringOrDefault("Email");
                        user.RoleId = datareader.GetInt64OrDefault("RoleId");
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return user;
        }
    }
}
