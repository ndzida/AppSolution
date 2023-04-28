using Models.Administration;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls.ViewModel
{
    public class AuthorizationViewModel
    {
        public bool IsChecked { get; set; }
        public int? AuthorizationId { get; set; }
        public string AuthorizationTitle { get; set; }
    }
}
