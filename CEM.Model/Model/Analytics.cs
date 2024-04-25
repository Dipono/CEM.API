using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class Analytics
    {
        public Analytics() {
            NameType = string.Empty;
        }
        public string NameType { get; set; }
        public int ResultCount { get; set; }
    }
}
