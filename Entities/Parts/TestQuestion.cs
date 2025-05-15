namespace Task2.Entities.Parts;

public class TestQuestion
{
    public string Content { get; set; } = string.Empty;
    public List<TestAnswer> Answers { get; set; } = new List<TestAnswer>()
    {
        new TestAnswer("", false)
    };
}