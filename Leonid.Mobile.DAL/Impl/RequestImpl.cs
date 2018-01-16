using Leonid.Mobile.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leonid.Mobile.DAL.Data;
using P3Net.Data.Common;
using System.Data;

namespace Leonid.Mobile.DAL.Impl
{
    public class RequestImpl : IRequest
    {
        public List<Location> GetItemLocations()
        {
            List<Location> locations = null;

            try
            {
                StoredProcedure coreCustomerProcedure = new StoredProcedure("");

                using (IDataReader datareader = DataConnectionHelper.GetConnectionManager().ExecuteReader(coreCustomerProcedure))
                {
                    while (datareader.Read())
                    {
                        Location location = new Location();

                        //location.LocationId = datareader.GetInt64OrDefault("UserID");
                        //location.LocationName = datareader.GetStringOrDefault("Name");

                        locations.Add(location);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return locations;
        }
    }
}
