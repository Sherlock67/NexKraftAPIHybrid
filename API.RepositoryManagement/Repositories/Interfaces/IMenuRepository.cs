using API.Data.ORM.MsSQLDataModels;
using API.ViewModel.ViewModels.Menus;
using API.ViewModel.ViewModels.Module;
using API.ViewModel.ViewModels.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.RepositoryManagement.Repositories.Interfaces
{
    public interface IMenuRepository 
    {
        Task<Menu> UpdateMenu(vmMenu menu);
        Task<Menu?> GetMenuInfo(int menuId);
        Task<Menu> CreateMenu(vmMenu menu);
        Task<List<Menu?>> GetMenuList(MenuData param);
        Task<bool> DeleteMenu (int id);
    }
}
