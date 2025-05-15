using Task2.Entities;

namespace Task2.UserControls;

public class TestView
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int QuestionCount { get; set; }

    public static TestView Create(Test entity)
    {
        TestView view = new TestView();
        view.Id = entity.Id;
        view.Title = entity.Title;
        view.QuestionCount = entity.ParseQuestions().Count;

        return view;
    }
}