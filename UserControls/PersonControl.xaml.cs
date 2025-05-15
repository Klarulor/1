using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Task2.Entities;
using Task2.Windows;

namespace Task2;

public partial class PersonControl : UserControl
{
    private readonly bool _isStudentControl;
    public PersonControl(bool isStudentControl)
    {
        _isStudentControl = isStudentControl;
        InitializeComponent();

        FillTable();
    }
   
    private async void FillTable()
    {
        var persons = await Person.GetAllAsync(_isStudentControl);
        
        Console.WriteLine(persons.Count());
        var list = new ObservableCollection<PersonView>();
        foreach(var p in persons)
            list.Add(PersonView.Create(p));
        Table.ItemsSource = list;
    }
    
    private void OnCreateButtonClicked(object sender, RoutedEventArgs e)
    {
        var win = new PersonInfoWindow(null, _isStudentControl);
        win.Closed += (s, args) =>
        {
            FillTable();
        };
        win.Show();
    }

    private void OnEditButtonClicked(object sender, RoutedEventArgs e)
    {
        var personV = (PersonView)Table.SelectedItem;
        var person = ((Person)personV);
        var win = new PersonInfoWindow(person, _isStudentControl);
        win.Closed += (s, args) =>
        {
            FillTable();
        };
        win.Show();
    }

    private void OnDeleteButtonClicked(object sender, RoutedEventArgs e)
    {
        var person = (PersonView)Table.SelectedItem;
        ((Person)person).Delete();
        FillTable();
    }

    private void Table_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        EditButton.IsEnabled = true;
        DeleteButton.IsEnabled = true;
    }
}
