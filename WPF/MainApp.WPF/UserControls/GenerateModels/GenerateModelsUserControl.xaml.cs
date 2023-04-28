using Common.FileManagement;
using Common.SqlServerManagement;
using MainApp.WPF.UserControls.GenerateModels.Models;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for GenerateModelsUserControl.xaml
    /// </summary>
    public partial class GenerateModelsUserControl : UserControl
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string FolderPath { get; set; }
        public GenerateModelsUserControl()
        {
            InitializeComponent();
            cbxServers.ItemsSource = SqlServerManagement.GetServerList();
        }

        #region UI Events
        private void cbxServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServerName = ((ComboBox)sender).SelectedValue.ToString();
            cbxDatabases.ItemsSource = SqlServerManagement.GetDatabaseList(ServerName);
        }

        private void cbxDatabases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseName = ((ComboBox)sender).SelectedValue.ToString();
            List<TableForExport> tfe = new List<TableForExport>();
            foreach (Table table in SqlServerManagement.GetTableList(ServerName, DatabaseName))
            {
                tfe.Add(new TableForExport()
                {
                    Table = table,
                    IsCheckedForExport = false
                });
            }
            dataGridTables.ItemsSource = tfe;

            List<ViewForExport> vfe = new List<ViewForExport>();
            foreach (View view in SqlServerManagement.GetViewlist(ServerName, DatabaseName))
            {
                vfe.Add(new ViewForExport()
                {
                    View = view,
                    IsCheckedForExport = false
                });
            }
            dataGridViews.ItemsSource = vfe;
        }
        #endregion

        #region Generate POCOs
        /// <summary>
        /// Based on used namespace and class we are creating header for future model class
        /// </summary>
        /// <param name="@namespace">Volatile operator</param>
        /// <param name="@class">Volatile operator</param>
        /// <returns></returns>
        private string CreateCSHeader(string @namespace, string @class)
        {
            //replace plural table name with singular
            TableName = @class;
            if (TableName.EndsWith("ies"))
            {
                TableName = TableName.Remove(TableName.Length - 3, 3) + "y";
            }
            if (TableName.EndsWith("s"))
            {
                TableName = TableName.Remove(TableName.Length - 1, 1) + "";
            }
            return $"using System;\n\n" +
                   $"namespace {@namespace}\n" +
                   $"{{\n" +
                   $"\tpublic class {TableName}\n" +
                   $"\t{{\n";
        }
        private string CreatePOCOModel(string columnType, string columnName)
        {
            return $"\t\tpublic {columnType} {columnName} {{ get; set; }}\n";
        }
        private string CreateCSFooter()
        {
            return $"\t}}\n}}";
        }
        private void GenerateModelsForSelectedData()
        {
            try
            {
                List<ModelForExport> mfe = new List<ModelForExport>();
                foreach (var item in dataGridTables.Items)
                {
                    if (item is TableForExport tfe)
                    {
                        StringBuilder sb = new StringBuilder();
                        if (tfe.IsCheckedForExport)
                        {
                            sb.Append(CreateCSHeader(tBoxNamespace.Text, tfe.Table.Name));
                            foreach (Column column in SqlServerManagement.GetColumnList(ServerName, DatabaseName, tfe.Table, null))
                            {
                                sb.Append(CreatePOCOModel(SqlServerHelpers.GetTypeAlias(column), column.Name));
                            }
                            sb.Append(CreateCSFooter());

                            //model to generate
                            mfe.Add(new ModelForExport()
                            {
                                Model = sb.ToString(),
                                FileName = $"{TableName}.cs"
                            });
                        }
                    }
                }
                foreach (var item in dataGridViews.Items)
                {
                    if (item is ViewForExport vfe)
                    {
                        StringBuilder sb = new StringBuilder();
                        if (vfe.IsCheckedForExport)
                        {
                            sb.Append(CreateCSHeader(tBoxNamespace.Text, vfe.View.Name));
                            foreach (Column column in SqlServerManagement.GetColumnList(ServerName, DatabaseName, null, vfe.View))
                            {
                                sb.Append(CreatePOCOModel(SqlServerHelpers.GetTypeAlias(column), column.Name));
                            }
                            sb.Append(CreateCSFooter());

                            //model to generate
                            mfe.Add(new ModelForExport()
                            {
                                Model = sb.ToString(),
                                FileName = $"{vfe.View.Name}.cs"
                            });
                        }
                    }
                }

                if (mfe.Count > 0)
                {
                    CreateFiles(mfe);
                    MessageBox.Show("Models were successfully generated.", "Success", MessageBoxButton.OK);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error {e.Message} occured", "Failure", MessageBoxButton.OK);
            }
        }
        #endregion

        #region File Management
        /// <summary>
        /// Create models in folder which we defined
        /// </summary>
        /// <param name="modelsForExport"></param>
        private void CreateFiles(List<ModelForExport> modelsForExport)
        {
            foreach (ModelForExport model in modelsForExport)
            {
                FileManagement.CreateFile(FolderPath, model.FileName, model.Model);
            }
        }
        #endregion

        #region Validation
        private bool CheckForm()
        {
            bool isFormValid = false;

            if (cbxServers.SelectedItem == null)
            {
                errorServers.Visibility = Visibility.Visible;
                isFormValid = false;
            }
            else
            {
                errorServers.Visibility = Visibility.Collapsed;
                isFormValid = true;
            }

            if (cbxDatabases.SelectedItem == null)
            {
                errorDatabases.Visibility = Visibility.Visible;
                isFormValid = false;
            }
            else
            {
                errorDatabases.Visibility = Visibility.Collapsed;
                isFormValid = true;
            }

            if (tBoxNamespace.Text == "")
            {
                errorNamespace.Visibility = Visibility.Visible;
                isFormValid = false;
            }
            else
            {
                errorNamespace.Visibility = Visibility.Collapsed;
                isFormValid = true;
            }

            if (tBoxFolderPath.Text == "")
            {
                errorFolderPath.Visibility = Visibility.Visible;
                isFormValid = false;
            }
            else
            {
                errorFolderPath.Visibility = Visibility.Collapsed;
                isFormValid = true;
            }
            return isFormValid;
        }
        #endregion

        #region Buttons
        private void BtnFolderPath_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.SelectedPath = Environment.CurrentDirectory;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    FolderPath = dialog.SelectedPath;
                    tBoxFolderPath.Text = FolderPath;
                }
            }
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForm())
            {
                GenerateModelsForSelectedData();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            cbxServers.SelectedItem = -1;
            cbxDatabases.SelectedItem = -1;

            if (dataGridTables.ItemsSource != null)
            {
                foreach (var table in dataGridTables.ItemsSource)
                {
                    ((TableForExport)table).IsCheckedForExport = false;
                }
            }

            if (dataGridViews.ItemsSource != null)
            {
                foreach (var view in dataGridViews.ItemsSource)
                {
                    ((ViewForExport)view).IsCheckedForExport = false;
                }
            }

            tBoxNamespace.Text = "";
            tBoxFolderPath.Text = "";

            errorServers.Visibility = Visibility.Collapsed;
            errorDatabases.Visibility = Visibility.Collapsed;
            errorNamespace.Visibility = Visibility.Collapsed;
            errorFolderPath.Visibility = Visibility.Collapsed;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        #endregion
    }
}
