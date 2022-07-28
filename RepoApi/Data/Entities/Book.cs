using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Data.Entities
{
    public class Book:BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
