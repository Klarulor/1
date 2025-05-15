using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task2.Entities;

namespace Task2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        PasswordTextBox.Password = "*******";
        
        MenuWindow mw = new MenuWindow();
        mw.Show();
        this.Close();
    }

    private bool _firstLoginFocus=false, _firstPasswordFocus=false;
    private void EmailTextBox_OnGotFocus(object sender, RoutedEventArgs e)
    {
        if (!_firstLoginFocus)
        {
            _firstLoginFocus = true;
            EmailTextBox.Text = "";
        }
    }

    private void PasswordTextBox_OnGotFocus(object sender, RoutedEventArgs e)
    {
        if (!_firstPasswordFocus)
        {
            _firstPasswordFocus = true;
            PasswordTextBox.Password = "";
        }
    }

    private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        var user = await User.TryLogin(EmailTextBox.Text, PasswordTextBox.Password);
        if (user is null)
        {
            StatusLabel.Content = $"No matched user by email and password";
            PasswordTextBox.Password = "";
        }
        else
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }
    }
}