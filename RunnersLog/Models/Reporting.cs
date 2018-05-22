using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunnersLog.Models
{
    public class Reporting
    {
        public List<Run> Weekly { get; set; }
        public List<Run> Monthly { get; set; }

        public List<Run> Yearly { get; set; }
    }
}