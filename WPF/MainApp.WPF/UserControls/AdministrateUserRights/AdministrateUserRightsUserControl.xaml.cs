using MainApp.WPF.UserControls.AdministrateUserRights.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApp.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for AdministrateUserRightsUserControl.xaml
    /// </summary>
    public partial class AdministrateUserRightsUserControl : UserControl, INotifyPropertyChanged
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdminDB"].ConnectionString;
        private string selectedCategory;

        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties

        private ObservableCollection<string> categories;
        public ObservableCollection<string> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged("Categories"); }
        }

        private ObservableCollection<Dictionary<int, string>> categoryData;
        public ObservableCollection<Dictionary<int, string>> CategoryData
        {
            get { return categoryData; }
            set { categoryData = value; OnPropertyChanged("CategoryData"); }
        }

        #endregion

        public AdministrateUserRightsUserControl()
        {
            InitializeComponent();
            DataContext = this;

            SetCategories();
        }


        #region Data
        private void SetCategories()
        {
            Categories = new ObservableCollection<string>();
            string queryString = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME IN ('Applications', 'Authorizations', 'Roles', 'Users')";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Categories.Add(reader[i].ToString());
                        }
                    }
                    reader.Close();
                }
            }

            // If collection has any items select first one
            if (Categories.Count > 0)
            {
                lstvCategories.SelectedItem = Categories[0];
            }
        }

        private void SetCategoryData(string tableName)
        {
            Dictionary<int, string> categoryData = new Dictionary<int, string>();
            selectedCategory = tableName;
            string queryString = $"SELECT * FROM {tableName}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int key = 0;
                        string value = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetName(i).ToLower().Contains("id"))
                            {
                                key = int.Parse(reader[i].ToString());
                            }
                            if (reader.GetName(i).ToLower().Contains("name") ||
                                reader.GetName(i).ToLower().Contains("title"))
                            {
                                value = reader[i].ToString();
                            }
                        }
                        categoryData.Add(key, value);
                    }
                    reader.Close();
                }
            }

            // Create new object with CategoryData in it
            CategoryData = new ObservableCollection<Dictionary<int, string>>() { categoryData };

            // If collection has any items select first one
            if (CategoryData.Count > 0)
            {
                lstvCategoryData.SelectedItem = CategoryData[0].First();
            }
        }

        private void SetFormDetails(string strId)
        {
            // Remove any children
            contentHolder.Children.Clear();

            int id = int.Parse(strId);
            UserControl control;
            switch (selectedCategory)
            {
                case "Applications":
                    control = new ApplicationDetails(id);
                    ((ApplicationDetails)control).CollectionChange += AdministrateUserRightsUserControl_CollectionChanged;

                    contentHolder.Children.Add(control);
                    break;
                case "Authorizations":
                    control = new AuthorizationDetails(id);
                    ((AuthorizationDetails)control).CollectionChange += AdministrateUserRightsUserControl_CollectionChanged; ;

                    contentHolder.Children.Add(control);
                    break;
                case "Roles":
                    control = new RoleDetails(id);
                    ((RoleDetails)control).CollectionChange += AdministrateUserRightsUserControl_CollectionChanged; ;

                    contentHolder.Children.Add(control);
                    break;
                case "Users":
                    control = new UserDetails(id);
                    ((UserDetails)control).CollectionChange += AdministrateUserRightsUserControl_CollectionChanged; ;

                    contentHolder.Children.Add(control);
                    break;
                default:
                    control = new ApplicationDetails(id);
                    ((ApplicationDetails)control).CollectionChange += AdministrateUserRightsUserControl_CollectionChanged;
                    contentHolder.Children.Add(control);
                    break;
            }
        }

        private void AdministrateUserRightsUserControl_CollectionChanged(object sender, EventArgs e)
        {
            SetCategoryData(sender.ToString());
        }
        #endregion

        #region UI Events

        private void LstvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            string tableName;
            if (lv != null)
            {
                tableName = lv.SelectedItem.ToString();
                SetCategoryData(tableName);
            }
        }


        private void LstvCategoryData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                if (lv.SelectedItem != null)
                {
                    SetFormDetails(((KeyValuePair<int, string>)lv.SelectedItem).Key.ToString());
                }
            }
        }
        #endregion


    }
}
