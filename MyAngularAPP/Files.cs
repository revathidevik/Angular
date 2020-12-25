using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAngularAPP
{
    public class Files
    {
        public string Name { get; set; }
        public string type { get; set; }
    }

    public class Root
    {
        public List<Files> Files { get; set; }
    }
}
