using AutoMapper;
using Leonid.Mobile.BAL.Contract;
using Leonid.Mobile.Common;
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
    public class ItemImpl : IItem
    {
        //TODO : Find out the better ways to Inject the Dependencies
        #region Dependencies

        IMapper mapper;
        DALContracts.IItem DALRequest = new DALImpl.ItemImpl();

        #endregion

        public ItemImpl()
        {
            #region Mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DALData.Item, Item>();
                cfg.CreateMap<Request, DALData.Request>();
            });

            mapper = config.CreateMapper();
            #endregion
        }

        public List<Item> GetItems(string searchItem)
        {
            List<DALData.Item> items = DALRequest.GetItems(searchItem);

            return mapper.Map<List<Item>>(items);
        }

        public void RequestItem(Request request)
        {
            DALData.Request DALrequest = mapper.Map<DALData.Request>(request);

            bool isSuccess = DALRequest.RequestItem(DALrequest);

            //if (isSuccess)
            //    SendMail();
        }


        private void SendMail(string fromEmailId, string customerName)
        {
            //EmailHelper.SendEMail();
        }
    }

  
}
