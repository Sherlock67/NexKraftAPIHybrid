using API.ViewModel.ViewModels.Customers;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;

namespace API.BusinessLogic.Interface.Module
{
    public interface IModuleServices
    {
      //  Task<object?> DeleteCustomer(int id);
      //  Task<object?> GetCustomerByCustomerID(int id);
        Task<object?> GetModuleList(ModuleData param);
        Task<object?> CreateModule(vmModule data);
        //Task<object?> UpdateCustomer(vmCustomerUpdate data);
    }
}
