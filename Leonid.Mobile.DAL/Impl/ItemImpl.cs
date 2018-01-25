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
    public class ItemImpl : IItem
    {
        public List<Item> GetItems(string searchItem)
        {
            List<Item> items = new List<Item>();
            List<Location> locations = new List<Location>();

            try
            {
                StoredProcedure coreCustomerProcedure = new StoredProcedure("");
                coreCustomerProcedure.WithParameters(InputParameter.Named("SearchItem").WithValue(searchItem));

                //using (IDataReader datareader = DataConnectionHelper.GetConnectionManager().ExecuteReader(coreCustomerProcedure))
                //{
                //    while (datareader.Read())
                //    {
                //        Item item = new Item();

                //        item.ItemId = datareader.GetInt32OrDefault("ItemId");
                //        item.ItemName = datareader.GetStringOrDefault("ItemName");

                //        items.Add(item);
                //    }

                //    datareader.NextResult();

                //    while (datareader.Read())
                //    {
                //        Location location = new Location();

                //        location.LocationId = datareader.GetInt32OrDefault("LocationId");
                //        location.ItemId = datareader.GetInt32OrDefault("ItemId");
                //        location.ItemCount = datareader.GetInt32OrDefault("ItemCount");
                //        location.LocationName = datareader.GetStringOrDefault("Name");

                //        locations.Add(location);
                //    }
                //}

                items = new List<Item>()
                {
                    new Item ()
                    {
                        ItemId = 100,
                        ItemName = "Item 1",
                        Locations = new List<Location>()
                        {
                            new Location() { LocationId = 1, LocationName = "Bangalore", ItemCount = 10},
                            new Location() { LocationId = 2, LocationName = "Hyderabad", ItemCount = 20},
                            new Location() { LocationId = 3, LocationName = "Chennai", ItemCount = 30}
                        }
                    },
                    new Item ()
                    {
                        ItemId = 101,
                        ItemName = "Item 2",
                        Locations = new List<Location>()
                        {
                            new Location() { LocationId = 1, LocationName = "Bangalore", ItemCount = 15},
                            new Location() { LocationId = 2, LocationName = "Hyderabad", ItemCount = 25},
                            new Location() { LocationId = 3, LocationName = "Chennai", ItemCount = 35}
                        }
                    },
                    new Item ()
                    {
                        ItemId = 102,
                        ItemName = "Item 3",
                        Locations = new List<Location>()
                        {
                            new Location() { LocationId = 1, LocationName = "Bangalore", ItemCount = 18},
                            new Location() { LocationId = 2, LocationName = "Hyderabad", ItemCount = 28},
                            new Location() { LocationId = 3, LocationName = "Chennai", ItemCount = 38}
                        }
                    }
                };
            }
            catch (Exception ex)
            {

            }

            return items;
        }

        public bool RequestItem(Request request)
        {
            try
            {
                StoredProcedure coreRequestProcedure = new StoredProcedure("usp_InsertRequestDetails");

                coreRequestProcedure.WithParameters(InputParameter.Named("ItemName").WithValue(request.ItemName));
                coreRequestProcedure.WithParameters(InputParameter.Named("CustomerName").WithValue(request.CustomerName));
                coreRequestProcedure.WithParameters(InputParameter.Named("Ordervalue").WithValue(request.Ordervalue));
                coreRequestProcedure.WithParameters(InputParameter.Named("Quantity").WithValue(request.Quantity));
                coreRequestProcedure.WithParameters(InputParameter.Named("DispatchDate").WithValue(request.DispatchDate));
                coreRequestProcedure.WithParameters(InputParameter.Named("Remarks").WithValue(request.Remarks));

                int count = DataConnectionHelper.GetConnectionManager().ExecuteNonQuery(coreRequestProcedure);

                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
