using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_Final_Workshop.Model
{
    public class Race
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Animal>? Animals { get; set; } = new List<Animal>();
    }
}
