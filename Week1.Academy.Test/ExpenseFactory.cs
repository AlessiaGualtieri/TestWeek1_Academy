using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;

namespace Week1.Academy.Test
{
    public class ExpenseFactory
    {
        public static ICategoryExpense GetExpense(string category)
        {
            ICategoryExpense expense = null;
            switch (category)
            {
                case "Vitto":
                    expense = new FoodExpense();
                    break;
                case "Alloggio":
                    expense = new AccomodationExpense();
                    break;
                case "Viaggio":
                    expense = new TripExpense();
                    break;
                case "Altro":
                    expense = new OtherExpense();
                    break;
            }

            return expense;
        }
    }
}
