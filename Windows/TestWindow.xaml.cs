using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Task2.Entities;
using Task2.Entities.Parts;
using Task2.UserControls;

namespace Task2.Windows;

public partial class TestWindow : Window
{
    private const string CHARS = "qwertyuiopasdfghjklzxcvbnm1234567890";
    private Random _rnd = new Random();
    
    internal List<TestQuestion> _questions = new List<TestQuestion>();
    public TestWindow()
    {
        InitializeComponent();
        for (int i = 0; i < 5; i++)
        {
            char c = CHARS[_rnd.Next(0, CHARS.Length)];
            if(_rnd.Next(0, 2) == 0)
                PasswordTextBox.Text += $"{c}".ToUpper();
            else PasswordTextBox.Text += $"{c}";
            
        }
    }

    private void OnAppendQuestionClicked(object sender, RoutedEventArgs e)
    {
        TestQuestionWindow win = new TestQuestionWindow(this);
        win.Closed += (o, args) => FillTable();
        win.Show();
    }

    private void Table_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private async void FillTable()
    {
        var list = new ObservableCollection<TestWindowTableElement>();
        foreach(var q in _questions.Select(x => new TestWindowTableElement(x.Content)))
            list.Add(q);
        Table.ItemsSource = list;
    }
    
    private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
    {
        if (TitleTextBox.Text.Trim() == "")
        {
            MessageBox.Show("Title cannot be empty");
            return;
        }
        
        if (!Int32.TryParse(ExecutingTimeHourTimeBox.Text.Trim(), out var h)
            || !Int32.TryParse(ExecutingTimeMinuteTimeBox.Text.Trim(), out var m)
            || !Int32.TryParse(ExecutingTimeSecondTimeBox.Text.Trim(), out var s))
        {
            MessageBox.Show("Time cannot be empty or not number");
            return;
        }

        if (_questions.Count == 0 || _questions[0].Content == "")
        {
            MessageBox.Show("Question cannot be empty");
            return;
        }

        if (PasswordTextBox.Text.Trim() == "")
        {
            MessageBox.Show("Password cannot be empty");
            return;
        }

        int timeS = h * 3600 + m * 60 + s;
        
        if (timeS <= 0)
        {
            MessageBox.Show("Time cannot be negative");
            return;
        }
        
        Test test = new Test();
        test.Title = TitleTextBox.Text;
        test.ExecuteTimeS = timeS;
        test.TestPassword = PasswordTextBox.Text;
        test.MakeQuestions(_questions);
        test.Create();
        Close();
    }

    private class TestWindowTableElement
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public TestWindowTableElement(string content)
        {
            Title = content;
        }
    }
}