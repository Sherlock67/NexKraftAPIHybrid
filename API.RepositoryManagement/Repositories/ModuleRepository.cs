using API.Data.ORM.MsSQLDataModels;
using API.RepositoryManagement.Base;
using API.RepositoryManagement.Repositories.Interfaces;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;

namespace API.RepositoryManagement.Repositories
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        private NexKraftDbContext? NexKraftDbContext => _dbContext as NexKraftDbContext;
        public ModuleRepository(NexKraftDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Module?> GetModuleInfo(int moduleId)
        {
            return await GetByIdAsync(moduleId);
        }

        public async Task<List<Module>> GetModuleList(ModuleData param)
        {
            return (await GetManyAsync(
                filter: x => (

                x.ModuleName == param.Search

                ),
                orderBy: x => x.OrderBy(t => t.ModuleName),
                top: param.PageSize,
                skip: (param.PageNumber - 1) * param.PageSize
                )).ToList();
        }

        public async Task<Module> CreateModule(vmModule model)
        {
            Module objModule = new Module()
            {
                ModuleName = model.ModuleName,
                UpdatedBy = model.UpdatedBy,
                ÇreatedBy = model.ÇreatedBy
            };
            return await AddAsync(objModule);

            //throw new NotImplementedException();
        }
        public async Task<bool> DeleteModule(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<Module> UpdateModule(vmModule model)
        {
             throw new NotImplementedException();

        }
    }
}
