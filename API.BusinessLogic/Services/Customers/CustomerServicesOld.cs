﻿using API.Data.ADO.NET;
using API.ViewModel.ViewModels.Common;
using API.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.ViewModel.ViewModels.Customers;
using API.Data.ORM.MsSQLDataModels;
using API.BusinessLogic.Interface.Customer;
using Newtonsoft.Json;
using Azure;
using System.Xml;
using API.Data.MySQL;
using API.Data.PostGreSQL;
using Npgsql;
using System.Data;

namespace API.BusinessLogic.Services.Customers
{
    public class CustomerServicesOld: ICustomerServicesOld
    {
        Hashtable? ht;
        GenericFactory<vmCustomer>? objCustomer = null;
        GenericFactoryMySql<vmCustomer>? objCustomerMySQL = null;
        GenericFactoryPostgreSql<vmCustomer>? objCustomerPostgreSQL = null;
        PostGreSqlDbConnection PostGre;
        public CustomerServicesOld( PostGreSqlDbConnection db) {
            objCustomer = new GenericFactory<vmCustomer>();
            objCustomerMySQL = new GenericFactoryMySql<vmCustomer>();
            PostGre = db;
        }        
        public async Task<object?> GetCustomerList(CustomerData cmnParam)
        {
            if (StaticInfos.IsPostgreSQL)
            {
                await PostGre.Connection.OpenAsync();
                objCustomerPostgreSQL = new GenericFactoryPostgreSql<vmCustomer>(PostGre);
            }
            List<vmCustomer?>? listCustomer = new List<vmCustomer?>();
            try
            {
                if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                         {
                            { "PageIndex", cmnParam.PageNumber },
                            { "PageSize", cmnParam.PageSize},
                            { "Search", cmnParam.Search}
                         };
                    listCustomer = await objCustomer.ExecuteCommandList("[dbo].[SP_GetCustomersPageWise]", ht, StaticInfos.MsSqlConnectionString);

                }
                else if (StaticInfos.IsMySQL)
                {
                    ht = new Hashtable
                        {
                           { "PageIndex", cmnParam.PageNumber },
                           { "PageSize", cmnParam.PageSize},
                           { "Search", cmnParam.Search}
                        };
                    listCustomer = await objCustomerMySQL.ExecuteCommandList("SP_GetCustomersPageWise", ht, StaticInfos.MySqlConnectionString);
                }
                else if (StaticInfos.IsPostgreSQL)
                {
                    string functionName = "fnc_getcustomerlist(" + cmnParam.PageNumber + "," + cmnParam.PageSize + ",'" + cmnParam.Search + "')";
                    listCustomer = await objCustomerPostgreSQL.ExecuteQueryList(functionName);
                }

            }
            catch (Exception ex)
            {

            }
            return new
            {
                listCustomer
            };
        }
        public async Task<object?> GetCustomerByCustomerID(int id)
        {           
            vmCustomer? customer = new vmCustomer();
            if (StaticInfos.IsPostgreSQL)
            {
                await PostGre.Connection.OpenAsync();
                objCustomerPostgreSQL = new GenericFactoryPostgreSql<vmCustomer>(PostGre);
            }
            try
            {
                CommonData cmnParam = new CommonData();
                cmnParam.Id = id;
                if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                          {
                             { "CustomerID", cmnParam.Id}
                          };
                    customer = await objCustomer.ExecuteCommandSingle("SP_GetCustomerByCustomerID", ht, StaticInfos.MsSqlConnectionString);
                }
                else if (StaticInfos.IsMySQL)
                {
                    ht = new Hashtable
                          {
                             { "C_CustomerID", cmnParam.Id}
                          };
                    customer = await objCustomerMySQL.ExecuteCommandSingle("SP_GetCustomerByCustomerID", ht, StaticInfos.MySqlConnectionString);
                }
                else if (StaticInfos.IsPostgreSQL)
                {                   
                    string functionName = "fnc_getcustomer_by_id(" + cmnParam.Id + ")";
                    customer = await objCustomerPostgreSQL.ExecuteQuerySingleString(functionName);

                }

            }
            catch (Exception ex)
            {

            }
            return customer;
        }
        public async Task<object?> DeleteCustomer(int id)
        {
            if (StaticInfos.IsPostgreSQL)
            {
                await PostGre.Connection.OpenAsync();
                objCustomerPostgreSQL = new GenericFactoryPostgreSql<vmCustomer>(PostGre);
            }
            string message = string.Empty; bool resstate = false;
            try
            {
                CommonData cmnParam = new CommonData(); int response = 0;
                cmnParam.Id = id;
                if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                         {
                            { "CustomerID", cmnParam.Id}
                         };
                    response = await objCustomer.ExecuteCommand("SP_DeleteCustomer", ht, StaticInfos.MsSqlConnectionString);
                }
                else if (StaticInfos.IsMySQL)
                {
                    ht = new Hashtable
                         {
                            { "C_CustomerID", cmnParam.Id}
                         };
                    response = await objCustomerMySQL.ExecuteCommand("SP_DeleteCustomer", ht, StaticInfos.MySqlConnectionString);

                }
                else if (StaticInfos.IsPostgreSQL)
                {
                    var inParam = new Hashtable
                         {
                            { "customerid", cmnParam.Id}
                         };
                    var outParam = new Hashtable
                         {
                            { "is_success", false}
                         };
                    outParam = await objCustomerPostgreSQL.ExecuteCommand("sp_deletecustomer", inParam,outParam);
                    if (outParam.Count > 0)
                    {
                        foreach (DictionaryEntry obj in outParam)
                        {
                            if (Convert.ToString(obj.Key + "").Contains("is_success"))
                            {
                                response = Convert.ToBoolean(obj.Value) ? 1 : 0;
                            }
                        }
                    }
                    else
                    {
                        response = 1;
                    }

                }
                if (response > 0)
                {
                    message = "Deleted Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
        public async Task<object?> CreateCustomer(CreateCustomerModel objCtomer)
        {
            if (StaticInfos.IsPostgreSQL)
            {
                await PostGre.Connection.OpenAsync();
                objCustomerPostgreSQL = new GenericFactoryPostgreSql<vmCustomer>(PostGre);
            }
            
            string message = string.Empty; bool resstate = false; int response = 0;
            try
            {
                if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                     {
                      { "CustomerName", objCtomer?.CustomerName},
                      { "Country", objCtomer?.Country },
                      { "Email", objCtomer?.Email }
                     };
                    response = await objCustomer.ExecuteCommand("SP_CreateCustomer", ht, StaticInfos.MsSqlConnectionString);

                }
                else if (StaticInfos.IsMySQL)
                {
                    ht = new Hashtable
                     {
                      { "C_CustomerName", objCtomer?.CustomerName},
                      { "C_Country", objCtomer?.Country }
                     };
                    response = await objCustomerMySQL.ExecuteCommand("SP_CreateCustomer", ht, StaticInfos.MySqlConnectionString);
                }
                else if (StaticInfos.IsPostgreSQL)
                {
                    var inParam = new Hashtable
                     {
                      { "customername", objCtomer?.CustomerName},
                      { "country", objCtomer?.Country }
                     };
                    var outParam = new Hashtable
                        {
                           { "is_success", false}
                        };
                    outParam = await objCustomerPostgreSQL.ExecuteCommand("sp_createcustomer", inParam, outParam);
                    if (outParam.Count > 0)
                    {
                        foreach (DictionaryEntry obj in outParam)
                        {
                            if (Convert.ToString(obj.Key + "").Contains("is_success"))
                            {
                                response = Convert.ToBoolean(obj.Value) ? 1 : 0;
                            }
                        }
                    }
                    else
                    {
                        response = 1;
                    }
                }

                if (response > 0)
                {
                    message = "Created Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
        public async Task<object?> UpdateCustomer(vmCustomerUpdate? objCtomer)
        {
            if (StaticInfos.IsPostgreSQL)
            {
                await PostGre.Connection.OpenAsync();
                objCustomerPostgreSQL = new GenericFactoryPostgreSql<vmCustomer>(PostGre);
            }
            string message = string.Empty; bool resstate = false;
            try
            {
                int response = 0;

                if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                        {
                           { "CustomerID", objCtomer?.CustomerID},
                           { "CustomerName", objCtomer?.CustomerName},
                           { "Country", objCtomer?.Country }
                        };
                    response = await objCustomer.ExecuteCommand("SP_UpdateCustomer", ht, StaticInfos.MsSqlConnectionString);
                }
                else if (StaticInfos.IsMsSQL)
                {
                    ht = new Hashtable
                        {
                           { "C_CustomerID", objCtomer?.CustomerID},
                           { "C_CustomerName", objCtomer?.CustomerName},
                           { "C_Country", objCtomer?.Country }
                        };
                    response = await objCustomerMySQL.ExecuteCommand("SP_UpdateCustomer", ht, StaticInfos.MySqlConnectionString);
                }
                else if (StaticInfos.IsPostgreSQL)
                {
                    var inParam = new Hashtable
                        {
                           { "customerid", objCtomer?.CustomerID},
                           { "customername", objCtomer?.CustomerName},
                           { "country", objCtomer?.Country }
                        };
                    var outParam = new Hashtable
                        {
                           { "is_success", false}
                        };
                    outParam = await objCustomerPostgreSQL.ExecuteCommand("sp_updatecustomer", inParam, outParam);
                    if (outParam.Count>0)
                    {
                        foreach (DictionaryEntry obj in outParam)
                        {
                            if (Convert.ToString(obj.Key + "").Contains("is_success"))
                            {
                                response = Convert.ToBoolean(obj.Value) ? 1 : 0;
                            }
                        }
                    }
                    else
                    {
                        response = 1;
                    }
                }


                if (response > 0)
                {
                    message = "Updated Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed.";
                }
            }
            catch (Exception ex)
            {

            }
            return new { message, resstate };
        }
    }
}
