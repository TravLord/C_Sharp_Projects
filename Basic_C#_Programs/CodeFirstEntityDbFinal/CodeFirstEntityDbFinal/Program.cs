using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstEntityDbFinal
{
    class Program
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



        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public virtual List<Grade> Grades { get; set; }

        }
        public class Grade
        {
            public int GradeId { get; set; }
            public string ClassName { get; set; }
            public virtual Student Student { get; set; }
            public int StudentId { get; set; }

        }

        public class SchoolContext : DbContext // Deverived context-> this allows classes to be queired and have db structure
        {
            public DbSet<Student> Students { get; set; }
            public DbSet<Grade> Grades { get; set; }
        }
    }
}
