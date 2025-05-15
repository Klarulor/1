using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Task2.Entities.Parts;
using Task2.UserControls;

namespace Task2.Windows;

public partial class TestQuestionWindow : Window
{
    private readonly TestWindow _testWindow;
    private readonly TestQuestion _testQuestion = new TestQuestion();
    
    public TestQuestionWindow()
    {
        InitializeComponent();
        FillTable();
    }

    public TestQuestionWindow(TestWindow test) : this()
    {
        _testWindow = test;
    }

    private void Table_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }
    
    private async void FillTable()
    {
        var list = new ObservableCollection<TestAnswer>();
        foreach(var p in _testQuestion.Answers)
            list.Add(p);
        Table.ItemsSource = list;
    }

    private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
    {
        if (_testQuestion.Answers.Count == 1 && _testQuestion.Answers[0].Content.Trim( )== "")
        {
            MessageBox.Show("Answer count is zero");
            return;
        }

        if (QuestionContentTextBox.Text.Trim() == "")
        {
            MessageBox.Show("Content is empty");
            return;
        }
        
        _testQuestion.Content = QuestionContentTextBox.Text;
        _testQuestion.Answers = new List<TestAnswer>(Table.ItemsSource as IEnumerable<TestAnswer>);

        if (_testQuestion.Answers.Any(x => x.Content.Trim() == ""))
        {
            MessageBox.Show("Answer title is empty");
            return;
        }

        if (_testQuestion.Answers.All(x => !x.IsCorrect))
        {
            MessageBox.Show("One answer must be correct");
            return;
        }
        
        _testWindow._questions.Add(_testQuestion);
        Close();
    }

    // private void OnAppendTableClicked(object sender, RoutedEventArgs e)
    // {
    //     _testQuestion.Answers.Add(new TestAnswer("", false));
    // }
}