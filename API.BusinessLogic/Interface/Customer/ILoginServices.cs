﻿using API.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BusinessLogic.Interface.Customer
{
    public interface ILoginServices
    {
        Task<object> LoginUser(LoginCredential credential,string userAgent,string remoteIpAddress);
        Task<string> GenerateNewToken(LoginModel userInfo, string userAgent, string remoteIpAddress);
    }
}
