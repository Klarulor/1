using Dapper;

namespace Task2.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public bool IsStudent { get; set; }

    private bool _new = false;
    
    public Person(){}
    private Person(bool isNew){_new = isNew;}
    
    public static Task<IEnumerable<Person>> GetAllAsync(bool? isStudent=null)
        => App.Connection.QueryAsync<Person>(isStudent is null ?
            $"SELECT * FROM persons"
            : $"SELECT * FROM persons WHERE IsStudent = {((bool)isStudent ? 1 : 0)}");

    public static Task<IEnumerable<Person>> GetAllStudents()
        => GetAllAsync(true);
    public static Task<IEnumerable<Person>> GetAllTeachers()
        => GetAllAsync(false);

    public void Save()
    {
        if (!_new)
        {
            Console.WriteLine("Updating Person");
            var sql = @"
                UPDATE persons 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Phone = @Phone, 
                    Email = @Email, 
                    Age = @Age 
                WHERE Id = @Id";

            App.Connection.Execute(sql, this);
        }
        else
        {
            Console.WriteLine("Inserting Person");
            var sql = @$"INSERT INTO persons (FirstName, LastName, Phone, Email, Age, IsStudent) 
                            VALUES (@FirstName, @LastName, @Phone, @Email, @Age, @IsStudent)";
            App.Connection.Execute(sql, this);
        }
    }

    public void Delete()
    {
        App.Connection.Execute($"DELETE FROM persons WHERE id = {Id}");
    }

    public static Person Create()
    {
        return new Person(true);
    }
}