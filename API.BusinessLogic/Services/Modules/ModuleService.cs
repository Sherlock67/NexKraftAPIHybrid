using API.BusinessLogic.Interface.Module;
using API.Data.ORM.MsSQLDataModels;
using API.RepositoryManagement.UnityOfWork.Interfaces;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;

namespace API.BusinessLogic.Services.Modules
{
    public class ModuleService : IModuleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModuleService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork; 
        }
        public async Task<object?> CreateModule(vmModule module)
        {
            string message = string.Empty; bool resstate = false; Module objModule = new();
            try
            {
                objModule = await _unitOfWork.ModuleRepository.CreateModule(module);
                await _unitOfWork.CompleteAsync();

                message = "Created Successfully.";
                resstate = true;

            }
            catch (Exception ex)
            {
                message = "Failed."; resstate = false;
            }
            return new
            {
                message,
                isSuccess = resstate
            };
        }

        public async Task<object?> GetModuleList(ModuleData param)
        {
            List<Module>? listModules = new List<Module>();
            try
            {
                listModules = await _unitOfWork.ModuleRepository.GetModuleList(param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new
            {
                listModules
            };
            
        }
    }
}
