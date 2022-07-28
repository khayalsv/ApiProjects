using System;

namespace KSApi.Data.Entities
{
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        
        //Many To Many
        public Student Student  { get; set; }
        public Course Course { get; set; }

    }
}
