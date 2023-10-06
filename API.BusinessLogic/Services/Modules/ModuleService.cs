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

        public async Task<object?> DeleteModule(int id)
        {
            string message = string.Empty; bool resstate = false; 
            try
            {
                await _unitOfWork.ModuleRepository.DeleteModule(id);
                await _unitOfWork.CompleteAsync();
                message = "Deleted Successfully.";
            }
            catch (Exception ex)
            {
                message = "Failed."; resstate = false;
            }
            return new
            {
                message,
                isSuccess = resstate,
            };
            // throw new NotImplementedException();
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

        public async Task<object?> UpdateModule(vmModule module)
        {

            string message = string.Empty; bool resstate = false; Module objModule = new();
            try
            {

                objModule = await _unitOfWork.ModuleRepository.GetModuleInfo(module.ModuleId);
                if(objModule != null)
                {
                    objModule.ModuleName = module.ModuleName;
                    //objModule.ÇreatedBy = module.ÇreatedBy;
                    objModule.UpdatedBy = module.UpdatedBy;
                    await _unitOfWork.CompleteAsync();
                    message = "Updated Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed."; resstate = false;
                }
                

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
    }
}
