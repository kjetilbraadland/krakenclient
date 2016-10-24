
using System.Collections.Generic;

namespace ConsoleApplication
{
   public class Job
    {
        public int JobId { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string ReservedBy { get; set; }
        public List<File> Files { get; set; }
    }
}