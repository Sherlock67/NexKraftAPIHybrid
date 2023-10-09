namespace API.ViewModel.ViewModels.Menus
{
    public class vmMenu
    {
        public int MenuId { get; set; }

        public string? MenuName { get; set; }

        public int? ParentId { get; set; }

        public int? SubParentId { get; set; }

        public bool? IsSubParentId { get; set; }

        public string? MenuIcon { get; set; }

        public string? MenuPath { get; set; }

        public int? MenuSequence { get; set; }

        public bool? IsActive { get; set; }
    }
    public class vmMenuUpdate
    {
        public int MenuId { get; set; }

        public string? MenuName { get; set; }

        public int? ParentId { get; set; }

        public int? SubParentId { get; set; }

        public bool? IsSubParentId { get; set; }

        public string? MenuIcon { get; set; }

        public string? MenuPath { get; set; }

        public int? MenuSequence { get; set; }

        public bool? IsActive { get; set; }

    }
}
