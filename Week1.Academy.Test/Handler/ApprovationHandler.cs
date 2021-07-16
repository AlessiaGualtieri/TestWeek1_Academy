using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;

namespace Week1.Academy.Test.Handler
{
    public class ApprovationHandler : AbstractHandler
    {
        public override void Handle(ICategoryExpense expense)
        {
            CeoHandler ceoHandler = new CeoHandler();
            ManagerHandler managerHandler = new ManagerHandler();
            OperationalManagerHandler operationalManagerHandler = new OperationalManagerHandler();

            this.SetNextHandler(managerHandler).SetNextHandler(operationalManagerHandler).SetNextHandler(ceoHandler);
            base.Handle(expense);
        }
    }
}
