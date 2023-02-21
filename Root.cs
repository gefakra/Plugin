using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Plugin
{
    public struct Root<T>
    {
        public List<T> users { get; set; }
    }
}
