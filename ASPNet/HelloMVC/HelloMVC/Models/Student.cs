using System.ComponentModel.DataAnnotations;

namespace HelloMVC.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(BirthDate)}: {BirthDate}";
    }
}