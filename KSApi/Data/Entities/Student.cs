using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Data.Entities
{
    public class Student :BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double? Salary { get; set; }
      
        
        //One To Many
        public int? GenderID { get; set; }
        public Gender Gender { get; set; }

        //Many To Many
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public bool IsDeleted { get; set; }

    }

 
}
