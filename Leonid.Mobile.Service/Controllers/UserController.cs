using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Leonid.Mobile.Service.Models;

using BALContracts = Leonid.Mobile.BAL.Contract;
using BALImpl = Leonid.Mobile.BAL.Impl;
using Leonid.Mobile.Data;
using System.Web.Http.Results;

namespace Leonid.Mobile.Services.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        #region Dependencies

        BALContracts.IUser BALUser = new BALImpl.UserImpl();

        #endregion

        // GET api/User
        [HttpGet]
        public OkResult Login()
        {
            return Ok();
        }

        // POST api/User
        [HttpPost]
        public User Login(Login loginCredentials)
        {
            if (loginCredentials == null 
                    || string.IsNullOrWhiteSpace(loginCredentials.UserName)
                    || string.IsNullOrWhiteSpace(loginCredentials.Password))
            {
                return null;
            }

            return BALUser.GetUserDetails(loginCredentials.UserName, loginCredentials.Password);
        }
    }
}
