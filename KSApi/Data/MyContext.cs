using KSApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KSApi.Data
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Course>().ToTable("tblCourse");
            //modelBuilder.Entity<Gender>().ToTable("tblGender");
            //modelBuilder.Entity<Student>().ToTable("tblStudent");
            //modelBuilder.Entity<StudentCourse>().ToTable("tblStudentCourse");

            modelBuilder.Entity<StudentCourse>().HasKey(x => new {x.StudentID, x.CourseID});

            //modelBuilder.Entity<Student>().HasQueryFilter(x => !x.IsDeleted);

        }
    }

}
