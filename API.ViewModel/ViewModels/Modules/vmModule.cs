using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModel.ViewModels.Module
{
    public class vmModule
    {
        public int ModuleId { get; set; }

        public string? ModuleName { get; set; }

        public string? ÇreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
    }
    public class vmModuleUpdate
    {
        public int ModuleId { get; set; }

        public string? ModuleName { get; set; }

        public string? ÇreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

    }
}
