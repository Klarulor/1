using Task2.Entities;

namespace Task2;

public class PersonView
{
    public PersonView(){}

    public PersonView(Person person)
    {
        Id = person.Id;
        FirstName = person.FirstName;
        LastName = person.LastName;
        Age = person.Age;
        Email = person.Email;
        Phone = person.Phone;
        isStudent = person.IsStudent;
    }
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public bool isStudent;

    public static PersonView Create(Person person)
        => new PersonView(person);
    
    public static implicit operator Person(PersonView vp)
    {
        var person = new Person();
        person.Id = vp.Id;
        person.FirstName = vp.FirstName;
        person.LastName = vp.LastName;
        person.Age = vp.Age;
        person.Email = vp.Email;
        person.Phone = vp.Phone;
        person.IsStudent = vp.isStudent;
        return person;
    }
}