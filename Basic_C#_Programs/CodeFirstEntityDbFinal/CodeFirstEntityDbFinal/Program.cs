using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityDbFinal
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var student = new Student() { Name = "Jabulba Triton" };

                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine(student);
            }
        }
            
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Grade Grade { get; set; }
        public int Age { get; set; }
    }

    public class Grade
    {
        public int IdGrade { get; set; }
        public string ClassName { get; set; }

        public string Quadrant { get; set; }
        public ICollection<Student> Students { get; set; }
    }

    public class SchoolContext : DbContext // Deverived context-> this allows classes to be queired and have db structure
    {
        public SchoolContext(): base()
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }

}
