
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DALContracts = Leonid.Mobile.DAL.Contract;
using DALData = Leonid.Mobile.DAL.Data;
using DALImpl = Leonid.Mobile.DAL.Impl;
using Leonid.Mobile.BAL.Contract;
using Leonid.Mobile.Data;
using AutoMapper;

namespace Leonid.Mobile.BAL.Impl
{
    public class UserImpl : IUser
    {
        //TODO : Find out the better ways to Inject the Dependencies
        #region Dependencies

        IMapper mapper;
        DALContracts.IUser DALUser = new DALImpl.UserImpl();

        #endregion

        public UserImpl()
        {
            #region Mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DALData.User, User>();
            });

            mapper = config.CreateMapper();
            #endregion
        }

        public User GetUserDetails(string userName, string password)
        {
            DALData.User user = DALUser.GetUserDetails(userName, password);

            return mapper.Map<User>(user);
        }
    }
}
