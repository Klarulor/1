using Dapper;

namespace Task2.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public static async Task<User?> TryLogin(string email, string password)
    {
        var r = await App.Connection.QueryAsync<User>(
            $"SELECT * FROM users WHERE email = @email AND password = @password LIMIT 1", new { email, password });
        return r.FirstOrDefault();
    }
}