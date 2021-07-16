using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Academy.Test.Entities
{
    public interface ICategoryExpense
    {
        public string Name { get; }
        public DateTime DateExpense { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public Approvation Approvation { get; set; }
        public double Reimburse { get {return GetReimburse();} }
        public double GetReimburse();

    }
}
