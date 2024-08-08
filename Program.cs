using EFCoreDemo.Models;

// (1) Create a new instance of the DbContext
// This connects to the database
using var db = new AppDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// (2) Create
Student studentOne = new Student { FirstName = "Kareem", LastName = "Dana", Age = 20 };

// (3) Add to database
db.Add(studentOne);

// (4) Save changes to the database
// Nothing takes effect until you save changes
db.SaveChanges();

// (5) Create a list of many students
List<Student> listOfStudents = new List<Student>() {
    new Student { FirstName = "Sean", LastName = "Humpherys", Age = 30 },
    new Student { FirstName = "Murray", LastName = "Jennex", Age = 40 },
    new Student { FirstName = "Amjad", LastName = "Abdullat", Age = 50 },
    new Student { FirstName = "Andrew", LastName = "Li", Age = 60 },
};

db.AddRange(listOfStudents);
db.SaveChanges();

foreach (Student s in db.Students)
{
    // Using the ToString() method in the Student entity class
    Console.WriteLine(s);
    // Without ToString() we need -
    //Console.WriteLine($"({s.StudentID}) {s.FirstName} {s.LastName} - {s.Age} years old.");
}

// db.Students.First() returns the First record in the database.
Student studentToUpdate = db.Students.First();
studentToUpdate.Age = 100; // Change the student's age
db.SaveChanges(); // Save the changes back to the database

// db.Students.Find(4) returns the Student record with a primary key of 4
Student anotherUpdate = db.Students.Find(4)!;
anotherUpdate.FirstName = "Jeff";
db.SaveChanges();

// List student data back again to see the changes
foreach (Student s in db.Students)
{
    Console.WriteLine(s);
}

Student studentToDelete = db.Students.Find(1)!;
db.Remove(studentToDelete);
db.SaveChanges();

foreach (Student s in db.Students)
{
    Console.WriteLine(s);
}