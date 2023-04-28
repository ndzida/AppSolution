using Models.Administration;
using System.Collections.Generic;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls.ViewModel
{
    public class UserApplicationViewModel
    {
        public bool IsChecked { get; set; }
        public int? UserId { get; set; }
        public int? ApplicationId { get; set; }
        public string ApplicationTitle { get; set; }
        public int? RoleId { get; set; }

        public Role SelectedRole { get; set; }
        public List<Role> Roles { get; set; }
    }
}
