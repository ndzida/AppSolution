using Microsoft.SqlServer.Management.Smo;

namespace MainApp.WPF.UserControls.GenerateModels.Models
{
    public class TableForExport : BaseExportClass
    {
        public Table Table { get; set; }
    }
}