﻿using Leonid.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonid.Mobile.BAL.Contract
{
    public interface IUser
    {
        User GetUserDetails(string userName, string password);
    }
}
