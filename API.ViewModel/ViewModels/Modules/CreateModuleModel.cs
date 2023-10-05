using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModel.ViewModels.Module
{
    public class CreateModuleModel
    {
        public int ModuleId { get; set; }

        public string? ModuleName { get; set; }

        public string? ÇreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
