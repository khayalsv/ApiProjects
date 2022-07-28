using System.Collections.Generic;

namespace KSApi.Data.Entities
{
    public class Gender
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //One to Many
        public ICollection<Student> Students { get; set; }
    }
}
