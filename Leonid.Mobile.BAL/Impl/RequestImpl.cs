using AutoMapper;
using Leonid.Mobile.BAL.Contract;
using Leonid.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DALContracts = Leonid.Mobile.DAL.Contract;
using DALData = Leonid.Mobile.DAL.Data;
using DALImpl = Leonid.Mobile.DAL.Impl;

namespace Leonid.Mobile.BAL.Impl
{
    public class RequestImpl : IRequest
    {
        //TODO : Find out the better ways to Inject the Dependencies
        #region Dependencies

        IMapper mapper;
        DALContracts.IRequest DALRequest = new DALImpl.RequestImpl();

        #endregion

        public RequestImpl()
        {
            #region Mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DALData.Location, Location>();
            });

            mapper = config.CreateMapper();
            #endregion
        }

        public List<Location> GetItemLocations()
        {
            List<DALData.Location> locations = DALRequest.GetItemLocations();

            return mapper.Map<List<Location>>(locations);
        }

    }
}
