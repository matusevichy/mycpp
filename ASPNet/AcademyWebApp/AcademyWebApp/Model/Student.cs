using System.ComponentModel.DataAnnotations;

namespace AcademyWebApp.Model;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public int? GroupID { get; set; }
    public Group Group { get; set; }
}