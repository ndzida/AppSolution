using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Controls;
using Models.Administration;

namespace MainApp.WPF.UserControls.AdministrateUserRights.UserControls
{
    /// <summary>
    /// Interaction logic for ApplicationDetailsUserControl.xaml
    /// </summary>
    public partial class ApplicationDetails : UserControl
    {
        private ApplicationDetailsDataContext ctx;
        public event EventHandler CollectionChange;

        #region Properties

        public bool CanNewExecute { get; set; }
        public bool CanEditExecute { get; set; }
        public bool CanSaveExecute { get; set; }
        public bool CanDeleteExecute { get; set; }
        #endregion

        public ApplicationDetails(int? id)
        {
            InitializeComponent();
            ctx = new ApplicationDetailsDataContext() { Id = id };
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
            CollectionChange?.Invoke("Applications", new EventArgs());
        }
        #endregion
    }

    internal class ApplicationDetailsDataContext : INotifyPropertyChanged
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

        private Application application;
        public Application Application
        {
            get { return application; }
            set { application = value; OnPropertyChanged("Application"); }
        }
        #endregion

        public ApplicationDetailsDataContext() { }

        public void GetDetails()
        {
            Application = new Application();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_SelectApplications", con))
                {
                    con.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApplicationId", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HeaderDetails = $"{reader[1].ToString()} details";

                        // Application object
                        Application.ApplicationId = int.Parse(reader["ApplicationId"].ToString());
                        Application.ApplicationTitle = $"{reader["ApplicationTitle"].ToString()}";
                        Application.UserCreated = $"{reader["UserCreated"].ToString()}";
                        Application.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                        Application.UserModified = $"{reader["UserModified"].ToString()}";
                        Application.DateModified = Common.TypeManagement.TypeManagement.TryParseDateTime(reader["DateModified"].ToString());
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
                    using (SqlCommand cmd = new SqlCommand("crud_InsertApplications", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ApplicationTitle", Application.ApplicationTitle);
                        cmd.Parameters.AddWithValue("@UserCreated", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                    IsErrorVisible = false;
                }
            }
            else
            {
                IsErrorVisible = true;
            }
        }

        public void UpdateDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_UpdateApplications", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ApplicationId", Application.ApplicationId);
                    cmd.Parameters.AddWithValue("@ApplicationTitle", Application.ApplicationTitle);
                    cmd.Parameters.AddWithValue("@UserCreated", Application.UserCreated);
                    cmd.Parameters.AddWithValue("@DateCreated", Application.DateCreated);
                    cmd.Parameters.AddWithValue("@UserModified", Environment.UserName);
                    cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("crud_DeleteApplications", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ApplicationId", Application.ApplicationId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsFormValid()
        {
            bool isFormValid = false;
            if (Application.ApplicationTitle != "")
            {
                isFormValid = true;
            }
            return isFormValid;
        }

        public void ResetDetailsForm()
        {
            Id = null;
            Application = new Application();
            ControlsEnabled = true;
        }
    }
}
