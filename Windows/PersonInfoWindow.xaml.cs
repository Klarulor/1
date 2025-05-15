using System.Windows;
using Task2.Entities;

namespace Task2.Windows;

public partial class PersonInfoWindow : Window
{
    private Person _person;
    private readonly bool _isNew;
    private readonly bool? _isStudent;
    
    public PersonInfoWindow(Person? person, bool? isStudent)
    {
        InitializeComponent();

        _isNew = person is null;
        _isStudent = isStudent;
        _person = person;
       
        if (person is null)
        {
            _person = Person.Create();
            InteractionButton.Content = "Create";
        }
        else
        {
            InteractionButton.Content = "Save";
            FirstNameTextBox.Text = person.FirstName;
            LastNameTextBox.Text = person.LastName;
            EmailTextBox.Text = person.Email;
            PhoneTextBox.Text = person.Phone;
            AgeTextBox.Text = person.Age.ToString();
        }
    }

    private void OnInteractionButtonClicked(object sender, RoutedEventArgs e)
    {
        _person.FirstName = FirstNameTextBox.Text;
        _person.LastName = LastNameTextBox.Text;
        _person.Email = EmailTextBox.Text;
        _person.Phone = PhoneTextBox.Text;
        _person.Age = Int32.Parse(AgeTextBox.Text);
        _person.IsStudent = _isStudent ?? false;
        _person.Save();
    }
}