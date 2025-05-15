using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Task2.Entities;
using Task2.Windows;

namespace Task2.UserControls;

public partial class TestsControl : UserControl
{
    public TestsControl()
    {
        InitializeComponent();
        FillTable();
    }

    private void Table_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }
    private async void FillTable()
    {
        var persons = await Test.GetAllAsync();
        
        Console.WriteLine(persons.Count());
        var list = new ObservableCollection<TestView>();
        foreach(var p in persons)
            list.Add(TestView.Create(p));
        Table.ItemsSource = list;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new TestWindow();
        window.Show();
        window.Closed += (s, args) => FillTable();
    }
}