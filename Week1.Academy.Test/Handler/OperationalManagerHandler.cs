using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;

namespace Week1.Academy.Test.Handler
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override void Handle(ICategoryExpense expense)
        {
            if (expense.Cost <= 1000)
            {
                expense.Approvation.State = State.Approved;
                expense.Approvation.Level = Level.OPS;
            }
            else
                base.Handle(expense);
        }
    }
}
