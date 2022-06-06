using BudgetPlanning.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanning.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<OperationExpense> OperationExpenses { get; set; }
        public DbSet<OperationEarning> OperationEarnings { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = BudgetPlanning.db");
        }
    }
}
