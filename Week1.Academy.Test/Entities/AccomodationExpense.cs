using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Academy.Test.Entities
{
    public class AccomodationExpense : ICategoryExpense
    {
        public string Name { get; } = "Alloggio";
        public DateTime DateExpense { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public Approvation Approvation { get; set; } = new Approvation();
        public double Reimburse { get { return GetReimburse(); } }
        public double GetReimburse()
        {
            return (this.Approvation.State == State.Approved) ? Cost : 0;
        }
    }
}
