﻿using API.BusinessLogic.Interface.Customer;
using API.ViewModel.ViewModels.Customers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly ICustomerServices serivce;
        public CustomerController(ICustomerServices service,IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.serivce= service;
        }

        [HttpGet("[action]")]//Authorizations        
        public async Task<object?> GetCustomerList([FromQuery] CustomerData param)
        {
            object? data = null;
            try
            {
                //DateTime currentTime;
                bool isExist = memoryCache.TryGetValue("CacheTime", out data);
                if (!isExist)
                {
                    //currentTime = DateTime.Now;
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMilliseconds(30));

                    data = await serivce.GetCustomerList(param);

                    memoryCache.Set("CacheTime", data, cacheEntryOptions);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return new
            {
                data
            };
        }

        [HttpGet("[action]")]//, Authorizations
        public async Task<object?> GetCustomerByCustomerID([FromQuery] int id)
        {
            object? data = null;
            try
            {
                data = await serivce.GetCustomerByCustomerID(id);
                if (data == null)
                {
                    data = new { message = "No data found" };
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return data;
        }

        [HttpPost("[action]")]//, Authorizations
        public async Task<object?> CreateCustomer([FromBody] CreateCustomerModel data)
        {
            object? resdata = null;
            try
            {
                resdata = await serivce.CreateCustomer(data);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;

        }

        [HttpPut("[action]")]//, Authorizations
        public async Task<object?> UpdateCustomer([FromBody] vmCustomerUpdate data)
        {
            object? resdata = null;
            try
            {
                resdata = await serivce.UpdateCustomer(data);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;
        }

        [HttpDelete("[action]")]//, Authorizations
        public async Task<object?> DeleteCustomer([FromQuery] int id)
        {
            object? resdata = null;
            try
            {
                resdata = await serivce.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;
        }
    }
}
