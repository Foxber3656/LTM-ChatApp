using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.Models
{
    public class Group
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Members { get; set; } = new();
    }
}
