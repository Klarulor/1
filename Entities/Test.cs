using Dapper;
using Task2.Entities.Parts;

namespace Task2.Entities;

public class Test
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Questions { get; set; }
    public int ExecuteTimeS { get; set; } = 600;
    public string TestPassword { get; set; } = "";

    public List<TestQuestion> ParseQuestions()
        => Newtonsoft.Json.JsonConvert.DeserializeObject<List<TestQuestion>>(Questions);
    public void MakeQuestions(List<TestQuestion> questions)
    => Questions = Newtonsoft.Json.JsonConvert.SerializeObject(questions);

    public static Task<IEnumerable<Test>> GetAllAsync(bool? isStudent = null)
        => App.Connection.QueryAsync<Test>($"SELECT * FROM tests");

    public void Create()
    {
        var sql = @$"INSERT INTO tests (Id, Title, Questions, ExecuteTimeS, TestPassword) 
                            VALUES (@Id, @Title, @Questions, @ExecuteTimeS, @TestPassword)";
        App.Connection.Execute(sql, this);
    }
}