using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanning.Model
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string ExpenseCategory { get; set; }
    }
}
