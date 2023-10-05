using API.Data.ORM.MsSQLDataModels;
using API.RepositoryManagement.Base;
using API.RepositoryManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.RepositoryManagement.Repositories
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        private NexKraftDbContext? NexKraftDbContext => _dbContext as NexKraftDbContext;
        public ModuleRepository(NexKraftDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Module?> CreateModule(Module entity)
        {
            var obj = await NexKraftDbContext.Modules.AddAsync(entity);
            NexKraftDbContext.SaveChanges();
            return obj.Entity;
        }
        public IEnumerable<Module> GetAll()
        {
            try
            {
                return NexKraftDbContext.Modules.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
