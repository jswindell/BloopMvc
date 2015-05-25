using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloopMvc.Models
{
    public class BloopFile
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
        public String Content { get; set; }
    }
}