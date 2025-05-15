using System.Windows;
using Task2.UserControls;

namespace Task2;

public partial class MenuWindow : Window
{
    public MenuWindow()
    {
        InitializeComponent();
    }

    private void OnNavBarTeacherButtonClicked(object sender, RoutedEventArgs e)
    {
        MainGrid.Children.Clear();
        var control = new PersonControl(false);
        MainGrid.Children.Add(control);
    }

    private void OnNavBarStudentsButtonClicked(object sender, RoutedEventArgs e)
    {
        MainGrid.Children.Clear();
        var control = new PersonControl(true);
        MainGrid.Children.Add(control);
    }

    private void OnNavBarTestsButtonClicked(object sender, RoutedEventArgs e)
    {
        MainGrid.Children.Clear();
        var control = new TestsControl();
        MainGrid.Children.Add(control);
    }
}