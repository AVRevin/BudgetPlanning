using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanning.Model
{
    public class Earning
    {
        [Key]
        public int EarningId { get; set; }
        public string EarningCategory { get; set; }

    }
}
