using ToDoListApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ToDoListApp.DAL
{
    public class ToDoContext : DbContext
    {

        public ToDoContext() : base("ToDoContext")
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}