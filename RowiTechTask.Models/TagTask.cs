using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowiTechTask.Models
{
    public class TagTask
    {
        public int TaskId { get; set; }
        public int TagId { get; set; }
        public Task Task { get; set; }
        public Tag Tag { get; set; }
    }
}
