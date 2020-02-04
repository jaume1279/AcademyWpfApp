using Academy.Lib.Models;
using Common.Lib.Core;
using Microsoft.EntityFrameworkCore;

namespace Academy.Lib
{
    public class AcademyDbContext : DbContext
    {
        public DbSet<Student> StudentSet { get; set; }
        public DbSet<Subject> SubjectSet { get; set; }
        public DbSet<StudentSubject> StudentSubjectSet { get; set; }
        public DbSet<Exam> ExamSet { get; set; }
        public DbSet<StudentExam> StudentExamSet { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=D:\\IT_Academy\\C#\\ExamDecember2019\\WPFAcademy\\AcademyDb.sqlite");
        }

        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {

        }

        public AcademyDbContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);

        }
    }
}
