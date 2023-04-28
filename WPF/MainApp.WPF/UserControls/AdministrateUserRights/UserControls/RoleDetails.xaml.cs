using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls;
using MainApp.WPF.UserControls.AdministrateUserRights.UserControls.ViewModel;
using Models.Administration;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls
{
    /// <summary>
    /// Interaction logic for RoleDetailsUserControl.xaml
    /// </summary>
    public partial class RoleDetails : UserControl
    {
        private RoleDetailsDataContext ctx;
        public event EventHandler CollectionChange;

        #region Properties

        public bool CanNewExecute { get; set; }
        public bool CanEditExecute { get; set; }
        public bool CanSaveExecute { get; set; }
        public bool CanDeleteExecute { get; set; }
        #endregion

        public RoleDetails(int? id)
        {
            InitializeComponent();
            ctx = new RoleDetailsDataContext() { Id = id };
            DataContext = ctx;

            ctx.ControlsEnabled = false;

            CanNewExecute = true;
            CanEditExecute = CanDeleteExecute = (id != null) ? true : false;
            CanSaveExecute = false;

            ctx.GetDetails();
        }

        #region Commands

        private void NewCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanNewExecute;
        }
        private void EditCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanEditExecute;
        }
        private void SaveCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanSaveExecute;
        }
        private void DeleteCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanDeleteExecute;
        }

        private void NewCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CanNewExecute = CanDeleteExecute = CanEditExecute = false;
            CanSaveExecute = true;

            ctx.ResetDetailsForm();
        }
        private void EditCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CanEditExecute = CanDeleteExecute = CanNewExecute = false;
            CanSaveExecute = true;

            ctx.ControlsEnabled = true;
        }
        private void SaveCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CanEditExecute = CanDeleteExecute = CanNewExecute = true;
            CanSaveExecute = false;

            if (ctx.Id == null)
            {
                ctx.InsertDetails();
            }
            else
            {
                ctx.UpdateDetails();
            }
            ctx.ControlsEnabled = false;

            CollectionChanged();
        }
        private void DeleteCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CanEditExecute = CanSaveExecute = CanDeleteExecute = false;
            CanNewExecute = true;

            ctx.DeleteDetails();
            ctx.ResetDetailsForm();

            CollectionChanged();
        }
        #endregion

        #region Events
        private void CollectionChanged()
        {
            CollectionChange?.Invoke("Roles", new EventArgs());
        }
        #endregion
    }

    internal class RoleDetailsDataContext : INotifyPropertyChanged
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdminDB"].ConnectionString;

        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Properties
        public int? Id { get; set; }
        public string HeaderDetails { get; set; }

        private bool isErrorVisible;
        public bool IsErrorVisible
        {
            get { return isErrorVisible; }
            set { isErrorVisible = value; OnPropertyChanged("IsErrorVisible"); }
        }

        private bool controlsEnabled;
        public bool ControlsEnabled
        {
            get { return controlsEnabled; }
            set { controlsEnabled = value; OnPropertyChanged("ControlsEnabled"); }
        }

        private Role role;
        public Role Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged("Role"); }
        }

        private ObservableCollection<AuthorizationViewModel> authorizations;
        public ObservableCollection<AuthorizationViewModel> Authorizations
        {
            get { return authorizations; }
            set { authorizations = value; OnPropertyChanged("Authorizations"); }
        }

        #endregion

        public RoleDetailsDataContext() { }

        public void GetDetails()
        {
            Role = new Role();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_SelectRoles", con))
                {
                    con.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleId", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HeaderDetails = $"{reader[1].ToString()} details";

                        // Role object
                        Role.RoleId = int.Parse(reader["RoleId"].ToString());
                        Role.RoleTitle = $"{reader["RoleTitle"].ToString()}";
                        Role.UserCreated = $"{reader["UserCreated"].ToString()}";
                        Role.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                        Role.UserModified = $"{reader["UserModified"].ToString()}";
                        Role.DateModified = Common.TypeManagement.TypeManagement.TryParseDateTime(reader["DateModified"].ToString());
                    }
                    reader.Close();
                }
            }

            SetAuthorizations();
        }


        public void InsertDetails()
        {
            if (IsFormValid())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("crud_InsertRoles", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RoleTitle", Role.RoleTitle);
                        cmd.Parameters.AddWithValue("@UserCreated", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        // Return inserted ID so Authorizations can use it
                        Role.RoleId = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
                DeleteRoleAuthorizations();
                InsertRoleAuthorizations();

                IsErrorVisible = false;
            }
            else
            {
                IsErrorVisible = true;
            }
        }

        public void UpdateDetails()
        {
            if (IsFormValid())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Update existing role
                    using (SqlCommand cmd = new SqlCommand("crud_UpdateRoles", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RoleId", Role.RoleId);
                        cmd.Parameters.AddWithValue("@RoleTitle", Role.RoleTitle);
                        cmd.Parameters.AddWithValue("@UserCreated", Role.UserCreated);
                        cmd.Parameters.AddWithValue("@DateCreated", Role.DateCreated);
                        cmd.Parameters.AddWithValue("@UserModified", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
                DeleteRoleAuthorizations();
                InsertRoleAuthorizations();

                IsErrorVisible = false;
            }
            else
            {
                IsErrorVisible = true;
            }

        }

        public void DeleteDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_DeleteRoles", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleId", Role.RoleId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #region Authorization management

        // Update DataGrid
        public void SetAuthorizations()
        {
            var authorizationsViewModel = GetAuthorizations();
            var authorizationViewModelsUpdated = UpdateAuthorizations(authorizationsViewModel);

            Authorizations = new ObservableCollection<AuthorizationViewModel>(authorizationViewModelsUpdated);
        }

        /// <summary>
        /// Get authorizations and create View Model from them
        /// </summary>
        /// <returns></returns>
        private List<AuthorizationViewModel> GetAuthorizations()
        {
            var authorizationsViewModel = new List<AuthorizationViewModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"crud_SelectAuthorizations", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        authorizationsViewModel.Add(new AuthorizationViewModel
                        {
                            IsChecked = false,
                            AuthorizationId = int.Parse(reader["AuthorizationId"].ToString()),
                            AuthorizationTitle = reader["AuthorizationTitle"].ToString()
                        });
                    }
                    reader.Close();
                }
            }
            return authorizationsViewModel;
        }

        /// <summary>
        /// Update exisiting authorizations view model
        /// </summary>
        /// <param name="authorizationsViewModel"></param>
        /// <returns></returns>
        private List<AuthorizationViewModel> UpdateAuthorizations(List<AuthorizationViewModel> authorizationsViewModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Update authorizations
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.fn_GetRoleAuthorizations({Role.RoleId})", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int? authorizationId = Common.TypeManagement.TypeManagement.TryParseInt(reader["AuthorizationId"].ToString());
                        foreach (var authorization in authorizationsViewModel)
                        {
                            if (authorizationId == authorization.AuthorizationId)
                            {
                                authorization.IsChecked = true;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            return authorizationsViewModel;
        }

        private void DeleteRoleAuthorizations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Delete authorizations
                using (SqlCommand cmd = new SqlCommand("crud_RoleAuthorizationsDelete", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleId", Role.RoleId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertRoleAuthorizations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Add new/updated authorizations
                using (SqlCommand cmd = new SqlCommand("crud_RoleAuthorizationsInsert", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var authorization in Authorizations.Where(x => x.IsChecked))
                    {
                        // Remove old parameters
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@RoleId", Role.RoleId);
                        cmd.Parameters.AddWithValue("@AuthorizationId", authorization.AuthorizationId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        private bool IsFormValid()
        {
            bool isFormValid = false;
            if (Role.RoleTitle != "")
            {
                isFormValid = true;
            }
            return isFormValid;
        }

        public void ResetDetailsForm()
        {
            Id = null;
            Role = new Role();
            ControlsEnabled = true;

            SetAuthorizations();
        }
    }
}
