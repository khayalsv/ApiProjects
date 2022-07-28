using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Data.Entities
{
    public class Library : BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
    }
}
