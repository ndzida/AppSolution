using MainApp.WPF.UserControls.DataEncryption.Cryptography;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DataEncryption.xaml
    /// </summary>
    public partial class DataEncryptionUserControl : UserControl
    {
        public DataEncryptionUserControl()
        {
            InitializeComponent();
        }

        #region UI Events
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            tBoxEncryptionResult.Text = CryptoService.EncryptString(tBoxEncrypt.Text);
        }

        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            tBoxDecryptionResult.Text = CryptoService.DecryptString(tBoxDecrypt.Text);
        }
        #endregion
    }
}
