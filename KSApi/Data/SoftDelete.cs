using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Data
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
