namespace Task2.Entities.Parts;

public class TestAnswer
{
    public string Content { get; set; }
    public bool IsCorrect { get; set; }

    public TestAnswer(string content, bool isCorrect)
    {
        Content = content;
        IsCorrect = isCorrect;
    }
    public TestAnswer(){}
}