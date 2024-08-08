namespace EFCoreDemo.Models;

public class Student
{
    public int StudentID {get; set;} // Primary Key
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    // Newly added Age property
    public int Age {get; set;}

    public override string ToString()
    {
        return $"({StudentID}) {FirstName} {LastName} - {Age} years old.";
    }
}