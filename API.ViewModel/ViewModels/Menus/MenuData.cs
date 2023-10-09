using API.ViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModel.ViewModels.Menus
{
    public class MenuData : Paging
    {
        public string Search { get; set; } = "";

    }
}
