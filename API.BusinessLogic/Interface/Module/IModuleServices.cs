using API.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BusinessLogic.Interface.Module
{
    public interface IModuleServices
    {
      //  Task<object?> DeleteCustomer(int id);
      //  Task<object?> GetCustomerByCustomerID(int id);
        Task<object?> GetModuleList(CustomerData param);
        Task<object?> CreateModule(CreateCustomerModel data);
        //Task<object?> UpdateCustomer(vmCustomerUpdate data);
    }
}
