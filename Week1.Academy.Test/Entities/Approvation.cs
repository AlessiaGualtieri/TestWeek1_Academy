using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Academy.Test.Entities
{
    public enum State
    {
        Approved,
        Not_approved
    }

    public enum Level
    {
        MGR,
        OPS,
        CEO
    }
    public class Approvation
    {
        public State State { get; set; }
        public Level Level { get; set; }
    }
}
