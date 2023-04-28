using Models.Administration;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls
{
    /// <summary>
    /// Interaction logic for AuthorizationDetails.xaml
    /// </summary>
    public partial class AuthorizationDetails : UserControl
    {
        private AuthorizationDetailsDataContext ctx;
        public event EventHandler CollectionChange;

        #region Properties

        public bool CanNewExecute { get; set; }
        public bool CanEditExecute { get; set; }
        public bool CanSaveExecute { get; set; }
        public bool CanDeleteExecute { get; set; }
        #endregion

        public AuthorizationDetails(int? id)
        {
            InitializeComponent();
            ctx = new AuthorizationDetailsDataContext() { Id = id };
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
            CollectionChange?.Invoke("Authorizations", new EventArgs());
        }
        #endregion
    }

    internal class AuthorizationDetailsDataContext : INotifyPropertyChanged
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

        private Authorization authorization;
        public Authorization Authorization
        {
            get { return authorization; }
            set { authorization = value; OnPropertyChanged("Authorization"); }
        }
        #endregion

        public AuthorizationDetailsDataContext() { }

        public void GetDetails()
        {
            Authorization = new Authorization();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_SelectAuthorizations", con))
                {
                    con.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AuthorizationId", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HeaderDetails = $"{reader[1].ToString()} details";

                        // Authorization object
                        Authorization.AuthorizationId = int.Parse(reader["AuthorizationId"].ToString());
                        Authorization.AuthorizationTitle = $"{reader["AuthorizationTitle"].ToString()}";
                        Authorization.UserCreated = $"{reader["UserCreated"].ToString()}";
                        Authorization.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                        Authorization.UserModified = $"{reader["UserModified"].ToString()}";
                        Authorization.DateModified = Common.TypeManagement.TypeManagement.TryParseDateTime(reader["DateModified"].ToString());
                    }
                    reader.Close();
                }
            }
        }

        public void InsertDetails()
        {
            if (IsFormValid())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("crud_InsertAuthorizations", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AuthorizationTitle", Authorization.AuthorizationTitle);
                        cmd.Parameters.AddWithValue("@UserCreated", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
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
                    using (SqlCommand cmd = new SqlCommand("crud_UpdateAuthorizations", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AuthorizationId", Authorization.AuthorizationTitle);
                        cmd.Parameters.AddWithValue("@AuthorizationTitle", Authorization.AuthorizationTitle);
                        cmd.Parameters.AddWithValue("@UserCreated", Authorization.UserCreated);
                        cmd.Parameters.AddWithValue("@DateCreated", Authorization.DateCreated);
                        cmd.Parameters.AddWithValue("@UserModified", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
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
                using (SqlCommand cmd = new SqlCommand("crud_DeleteAuthorizations", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AuthorizationId", Authorization.AuthorizationId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsFormValid()
        {
            bool isFormValid = false;
            if (Authorization.AuthorizationTitle != "")
            {
                isFormValid = true;
            }
            return isFormValid;
        }

        public void ResetDetailsForm()
        {
            Id = null;
            Authorization = new Authorization();
            ControlsEnabled = true;
        }
    }
}
