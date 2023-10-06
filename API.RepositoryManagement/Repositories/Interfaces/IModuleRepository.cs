using API.Data.ORM.MsSQLDataModels;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.RepositoryManagement.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module> UpdateModule(vmModule model);
        Task<Module?> GetModuleInfo(int moduleId);
        Task<Module> CreateModule(vmModule model);
        Task<List<Module?>> GetModuleList(ModuleData param);
        Task<bool> DeleteModule(int id);

    }
}
