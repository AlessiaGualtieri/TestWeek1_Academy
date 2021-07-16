using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Academy.Test.Entities;
using Week1.Academy.Test.Handler;

namespace Week1.Academy.Test
{
    public class EventManager
    {
        public static ICollection<ICategoryExpense> Expenses = new List<ICategoryExpense>();

        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("New file {0} was created", e.Name);
            try
            {
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    string line;
                    ICategoryExpense expense;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if ((expense = AsCategoryExpense(line)) != null)
                            Expenses.Add(expense);
                        else
                            Console.WriteLine("Format line '{0}' in file '{1}' not correct", line, e.Name);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DetermineApprovation();

            try
            {
                string path = @"C:\Users\alessia.gualtieri\Desktop\Alessia\Avanade\Corso\Week1_Academy";
                using (StreamWriter writer = File.CreateText(path + @"\spese_elaborate.txt"))
                {
                    foreach (var expense in Expenses)
                    {
                        if (expense.Approvation.State == State.Approved)
                            writer.WriteLine($"{expense.DateExpense.ToShortDateString()};" +
                                $"{expense.Name};" +
                                $"{expense.Description};" +
                                $"APPROVATA;{expense.Approvation.Level};" +
                                $"{expense.Reimburse}");
                        else
                            writer.WriteLine($"{expense.DateExpense.ToShortDateString()};" +
                                $"{expense.Name};" +
                                $"{expense.Description};" +
                                $"RESPINTA;-;-");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void DetermineApprovation()
        {
            ApprovationHandler approvationHandler = new ApprovationHandler();

            foreach (var expense in Expenses)
            {
                approvationHandler.Handle(expense);
            }
        }

        public static ICategoryExpense AsCategoryExpense(string line)
        {
            ICategoryExpense expense;
            string[] values;
            int count = 0;
            values = line.Split(';');

            if ((expense = ExpenseFactory.GetExpense(values[1])) != null)
            {
                DateTime dateExpense;
                double cost;

                if (DateTime.TryParse(values[0], out dateExpense))
                {
                    expense.DateExpense = dateExpense;
                    count++;
                }
                expense.Description = values[2];
                if (Double.TryParse(values[3], out cost))
                {
                    expense.Cost = cost;
                    count++;
                }
            }

            if (count == 2)
                return expense;
            return null;

        }
    }
}
