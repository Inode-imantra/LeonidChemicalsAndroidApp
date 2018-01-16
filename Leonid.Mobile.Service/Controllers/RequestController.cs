using Leonid.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BALContracts = Leonid.Mobile.BAL.Contract;
using BALImpl = Leonid.Mobile.BAL.Impl;

namespace Leonid.Mobile.Service.Controllers
{
    [RoutePrefix("api/Request")]
    public class RequestController : ApiController
    {
        #region Dependencies

        BALContracts.IRequest BALRequest = new BALImpl.RequestImpl();

        #endregion

        // GET api/Request/Locations
        [Route("Locations")]
        public List<Location> GetAllLocations()
        {
            //Get all possible Locations to display in the grid as header.
            return BALRequest.GetItemLocations();
        }


        // POST api/Request/
        //[Route("Items/{searchItem}")]
        //public List<Item> SearchItems(string searchItem)
        //{
        //    //Get all Items based on the Search and for each location display what is the quantity of each item.

        //    return new List<Item>();
        //}
    }
}
