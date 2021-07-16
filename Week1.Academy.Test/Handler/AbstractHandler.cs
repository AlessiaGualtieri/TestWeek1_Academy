using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;

namespace Week1.Academy.Test.Handler
{
    public class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public virtual void Handle(ICategoryExpense expense)
        {
            if (_nextHandler != null)
                _nextHandler.Handle(expense);
            else
                expense.Approvation.State = State.Not_approved;

        }

        public IHandler SetNextHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
    }
}
