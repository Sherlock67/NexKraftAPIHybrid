using System;
using System.Collections.Generic;

namespace API.Data.ORM.MsSQLDataModels;

public partial class Module
{
    public int ModuleId { get; set; }

    public string? ModuleName { get; set; }

    public string? ÇreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
}
