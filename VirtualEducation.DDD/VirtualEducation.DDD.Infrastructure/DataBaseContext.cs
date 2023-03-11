using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Teacher.Entities;

namespace VirtualEducation.DDD.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }


        public DbSet<StoredEvent> StoredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
