# How to display checkboxes with 0 and 1 values mapped from SQLite in a .NET MAUI DataGrid?

In this article, we will show you how to display checkboxes with 0 and 1 values mapped from SQLite in a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml:
```xaml
<StackLayout>
    <syncfusion:SfDataGrid x:Name="dataGrid"
                            SelectionMode="Single"
                            AutoGeneratingColumn="dataGrid_AutoGeneratingColumn"
                            NavigationMode="Cell">

        <syncfusion:SfDataGrid.Columns>
            <syncfusion:DataGridCheckBoxColumn MappingName="IsChecked" HeaderText="Checked" />
        </syncfusion:SfDataGrid.Columns>
    </syncfusion:SfDataGrid>
</StackLayout>
```

## C#:
To prevent the auto-generation of the helper property column (which is a member of the model class and will be replaced by the IsChecked column), you should disable the generation of the helper property column.

```C#
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
```

## Model:
The code below illustrates how to use a helper property in the model class, which stores a value of 1 or 0 from the database. You can create a boolean property, **IsChecked**, in your model class that maps to this helper property (holding 0 or 1 values) for display in the DataGrid. If the IsChecked property is 1, the CheckBox will appear checked; if IsChecked is 0, the CheckBox will be unchecked.

```C#
public class OrderItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int OrderID { get; set; }
    public string Name { get; set; }
    public int TokenNo { get; set; }
    public string BillStatus { get; set; }
    public int Count { get; set; }
    public bool IsChecked
    {
        get
        {
            return Count == 1 ? true : false;
        }
        set
        {
            Count = value ? 1 : 0;
        }
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-display-checkboxes-with-values-mapped-from-SQLite-in-a-.NET-MAUI-DataGrid).
 
Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to display checkboxes with 0 and 1 values mapped from SQLite in a .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!