using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanning.Model
{
    public class OperationExpense
    {
        [Key]
        public int OperationId { get; set; }
        public Expense Expense { get; set; }
        public decimal Amount { get; set; }

        public DateTime OperationDate { get; set; }
        
        public string Comments { get; set; }

    }
}
