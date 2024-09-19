using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Syncfusion.Maui.Data;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Helper;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public static SampleDemoDatabase sampleDemoDatabase;
        public static SampleDemoDatabase SampleDemoDatabase
        {
            get
            {
                if (sampleDemoDatabase == null)
                    sampleDemoDatabase = new SampleDemoDatabase();
                return sampleDemoDatabase;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = SampleDemoDatabase.OrderItemsDataSource;
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "Count")
            {
                e.Cancel = true;
            }
        }
    }
}
