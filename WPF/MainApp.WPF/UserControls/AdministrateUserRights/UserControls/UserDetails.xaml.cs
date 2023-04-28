using MainApp.WPF.UserControls.AdministrateUserRights.UserControls.ViewModel;
using Models.Administration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : UserControl
    {
        private UserDetailsDataContext ctx;
        public event EventHandler CollectionChange;

        #region Properties

        public bool CanNewExecute { get; set; }
        public bool CanEditExecute { get; set; }
        public bool CanSaveExecute { get; set; }
        public bool CanDeleteExecute { get; set; }
        #endregion

        public UserDetails(int? id)
        {
            InitializeComponent();
            ctx = new UserDetailsDataContext() { Id = id };
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
            CollectionChange?.Invoke("Users", new EventArgs());
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Finding checked row
            var selectedUserApplication = (UserApplicationViewModel)((ComboBox)sender).DataContext;

            // Getting value from selected role
            var selectedRole = (Role)((ComboBox)sender).SelectedValue;

            // Updateing UserApplications
            foreach (var userApplication in ctx.UserApplications)
            {
                if (userApplication.ApplicationId == selectedUserApplication.ApplicationId && userApplication.UserId == selectedUserApplication.UserId)
                {
                    userApplication.RoleId = selectedRole.RoleId;
                }
            }
        }
        #endregion
    }

    public class UserDetailsDataContext : INotifyPropertyChanged
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

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        private ObservableCollection<UserApplicationViewModel> userApplications;
        public ObservableCollection<UserApplicationViewModel> UserApplications
        {
            get { return userApplications; }
            set { userApplications = value; OnPropertyChanged("UserApplications"); }

        }
        #endregion

        public UserDetailsDataContext() { }

        public void GetDetails()
        {
            User = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_SelectUsers", con))
                {
                    con.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HeaderDetails = $"{reader[1].ToString()} details";

                        // User object
                        User.UserId = int.Parse(reader["UserId"].ToString());
                        User.Username = $"{reader["Username"].ToString()}";
                        User.PasswordHash = $"{reader["PasswordHash"].ToString()}";
                        User.IsActive = bool.Parse(reader["IsActive"].ToString());
                        User.IsRegistered = bool.Parse(reader["IsRegistered"].ToString());
                        User.UserCreated = $"{reader["UserCreated"].ToString()}";
                        User.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                        User.UserModified = $"{reader["UserModified"].ToString()}";
                        User.DateModified = Common.TypeManagement.TypeManagement.TryParseDateTime(reader["DateModified"].ToString());
                    }
                    reader.Close();
                }
            }

            SetUserApplications();
            GetRoles();
        }

        public void InsertDetails()
        {
            if (IsFormValid())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("crud_InsertUsers", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", User.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", User.PasswordHash);
                        cmd.Parameters.AddWithValue("@IsActive", User.IsActive);
                        cmd.Parameters.AddWithValue("@IsRegistered", User.IsRegistered);
                        cmd.Parameters.AddWithValue("@UserCreated", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                DeleteUserApplications();
                InsertUserApplications();
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
                    using (SqlCommand cmd = new SqlCommand("crud_UpdateUsers", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", User.UserId);
                        cmd.Parameters.AddWithValue("@Username", User.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", User.PasswordHash);
                        cmd.Parameters.AddWithValue("@IsActive", User.IsActive);
                        cmd.Parameters.AddWithValue("@IsRegistered", User.IsRegistered);
                        cmd.Parameters.AddWithValue("@UserCreated", User.UserCreated);
                        cmd.Parameters.AddWithValue("@DateCreated", User.DateCreated);
                        cmd.Parameters.AddWithValue("@UserModified", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
                DeleteUserApplications();
                InsertUserApplications();
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
                using (SqlCommand cmd = new SqlCommand("crud_DeleteUsers", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", User.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
            DeleteUserApplications();
        }

        #region User Applications
        // Set DataGrid with data from DB
        public void SetUserApplications()
        {
            var userApplicationViewModel = GetUserApplications();
            var userApplicationViewModelUpdated = UpdateUserApplications(userApplicationViewModel);

            UserApplications = new ObservableCollection<UserApplicationViewModel>(userApplicationViewModelUpdated);
        }

        /// <summary>
        /// Get applications and create initial view model from them
        /// </summary>
        /// <returns></returns>
        private List<UserApplicationViewModel> GetUserApplications()
        {
            var userApplicationsViewModel = new List<UserApplicationViewModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"crud_SelectApplications", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userApplicationsViewModel.Add(new UserApplicationViewModel
                        {
                            IsChecked = false,
                            ApplicationId = int.Parse(reader["ApplicationId"].ToString()),
                            ApplicationTitle = reader["ApplicationTitle"].ToString(),
                            UserId = User.UserId,
                            RoleId = null,
                            Roles = GetRoles(),
                            SelectedRole = new Role()
                        });
                    }
                    reader.Close();
                }
            }
            return userApplicationsViewModel;
        }

        /// <summary>
        /// Update exisiting user applications view model
        /// </summary>
        /// <param name="userApplicationViewModel"></param>
        /// <returns></returns>
        private List<UserApplicationViewModel> UpdateUserApplications(List<UserApplicationViewModel> userApplicationsViewModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Update authorizations
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM fn_GetUserApplications({User.UserId})", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int? applicationId = Common.TypeManagement.TypeManagement.TryParseInt(reader["ApplicationId"].ToString());
                        int? roleId = Common.TypeManagement.TypeManagement.TryParseInt(reader["RoleId"].ToString());
                        int? userId = Common.TypeManagement.TypeManagement.TryParseInt(reader["UserId"].ToString());
                        foreach (var userApplication in userApplicationsViewModel)
                        {
                            if (applicationId == userApplication.ApplicationId && userId == userApplication.UserId)
                            {
                                userApplication.IsChecked = true;
                                userApplication.RoleId = roleId;
                                userApplication.SelectedRole = userApplication.Roles?.Where(x => x.RoleId == roleId).First();
                            }
                        }
                    }
                    reader.Close();
                }
            }
            return userApplicationsViewModel;
        }

        private void DeleteUserApplications()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Delete authorizations
                using (SqlCommand cmd = new SqlCommand("crud_UserApplicationsDelete", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", User.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertUserApplications()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Add new/updated authorizations
                using (SqlCommand cmd = new SqlCommand("crud_UserApplicationsInsert", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var userApplication in UserApplications.Where(x => x.IsChecked))
                    {
                        // Remove old parameters
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@ApplicationId", userApplication.ApplicationId);
                        cmd.Parameters.AddWithValue("@RoleId", userApplication.RoleId);
                        cmd.Parameters.AddWithValue("@UserId", userApplication.UserId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private List<Role> GetRoles()
        {
            var roles = new List<Role>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_SelectRoles", con))
                {
                    con.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add(new Role()
                        {
                            RoleId = int.Parse(reader["RoleId"].ToString()),
                            RoleTitle = $"{reader["RoleTitle"].ToString()}",
                        });
                    }
                    reader.Close();
                }
            }
            return roles;
        }
        #endregion

        private bool IsFormValid()
        {
            bool isFormValid = false;
            if (User.Username != "")
            {
                isFormValid = true;
            }
            return isFormValid;
        }

        public void ResetDetailsForm()
        {
            Id = null;
            User = new User();
            ControlsEnabled = true;

            SetUserApplications();
        }
    }
}
