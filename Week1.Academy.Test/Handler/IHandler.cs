using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;

namespace Week1.Academy.Test.Handler
{
    public interface IHandler
    {
        public IHandler SetNextHandler(IHandler handler);
        public void Handle(ICategoryExpense expense);
    }
}
