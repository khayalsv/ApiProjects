using System;
using System.Collections.Generic;

namespace KSApi.Data.Entities
{
    public class Course :BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationTime { get; set; }

        //Many To Many
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
