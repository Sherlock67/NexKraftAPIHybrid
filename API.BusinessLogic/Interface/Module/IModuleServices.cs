using API.ViewModel.ViewModels.Customers;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;

namespace API.BusinessLogic.Interface.Module
{
    public interface IModuleServices
    {
        Task<object?> UpdateModule(vmModule module);
        Task<object?> DeleteModule(int id);
        Task<object?> GetModuleList(ModuleData param);
        Task<object?> CreateModule(vmModule data);
        
    }
}
