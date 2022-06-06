using BudgetPlanning.Data;
using BudgetPlanning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanning.Model.Data
{
    public static class DataWorker
    {

        //получить все операции доходов
        public static List<OperationEarning> GetAllOperationEarnings()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.OperationEarnings.ToList();
                return result;
            }
        }

        //получить все операции расходов
        public static List<OperationExpense> GetAllOperationExpenses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.OperationExpenses.ToList();
                return result;
            }
        }

        //получить все категории доходов
        public static List<Earning> GetAllCategoryEarnings()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Earnings.ToList();
                return result;
            }
        }

        //получить все категории расходов
        public static List<Expense> GetAllCategoryExpenses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Expenses.ToList();
                return result;
            }
        }

        //создаем категорию доходов
        public static string CreateEarningCategory(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существует ли категория доходов
                bool checkIsExist = db.Earnings.Any(el => el.EarningCategory == name);
                if (!checkIsExist)
                {
                    Earning earning = new Earning { EarningCategory = name };
                    db.Earnings.Add(earning);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //создаем категорию расходов
        public static string CreateExpenseCategory(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли категория расходов
                bool checkIsExist = db.Expenses.Any(el => el.ExpenseCategory == name);
                if (!checkIsExist)
                {
                    Expense expense = new Expense { ExpenseCategory = name };
                    db.Expenses.Add(expense);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }


        //создать операцию доходов
        public static string CreateOperationEarning(Earning earning, decimal amount, DateTime operation_date, string comments)
        {
            string result = "Не получилось создать операцию доходов";
            using (ApplicationContext db = new ApplicationContext())
            {

                OperationEarning operationEarning = new OperationEarning
                {

                    Earning = earning,
                    Amount = amount,
                    OperationDate = operation_date,
                    Comments = comments
                };
                db.OperationEarnings.Add(operationEarning);
                db.SaveChanges();
                result = "Создано!";
            }
            return result;
        }

        //создать операцию расходов
        public static string CreateOperationExpenses(Expense expense, decimal amount, DateTime operationDate, string comments)
        {
            string result = "Не получилось создать операцию доходов";
            using (ApplicationContext db = new ApplicationContext())
            {

                OperationExpense operationExpense = new OperationExpense
                {

                    Expense = expense,
                    Amount = amount,
                    OperationDate = operationDate,
                    Comments = comments
                };
                db.OperationExpenses.Add(operationExpense);
                db.SaveChanges();
            }
            return result;
        }








        //      }
        //      //создать сотрудника
        //      public static string CreateUser(string name, string surName, string phone, Position position)
        //      {
        //          string result = "Уже существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              //check the user is exist
        //              bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
        //              if (!checkIsExist)
        //              {
        //                  User newUser = new User
        //                  {
        //                      Name = name,
        //                      SurName = surName,
        //                      Phone = phone,
        //                      PositionId = position.Id
        //                  };
        //                  db.Users.Add(newUser);
        //                  db.SaveChanges();
        //                  result = "Сделано!";
        //              }
        //              return result;
        //          }
        //      }
        //      //удаление отдел
        //      public static string DeleteDepartment(Department department)
        //      {
        //          string result = "Такого отела не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              db.Departments.Remove(department);
        //              db.SaveChanges();
        //              result = "Сделано! Отдел " + department.Name + " удален";
        //          }
        //          return result;
        //      }
        //      //удаление позицию
        //      public static string DeletePosition(Position position)
        //      {
        //          string result = "Такой позиции не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              //check position is exist
        //              db.Positions.Remove(position);
        //              db.SaveChanges();
        //              result = "Сделано! Позиция " + position.Name + " удалена";
        //          }
        //          return result;
        //      }
        //      //удаление сотрудника
        //      public static string DeleteUser(User user)
        //      {
        //          string result = "Такого сотрудника не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              db.Users.Remove(user);
        //              db.SaveChanges();
        //              result = "Сделано! Сотрудник " + user.Name + " уволен";
        //          }
        //          return result;
        //      }
        //      //редактирование отдел
        //      public static string EditDepartment(Department oldDepartment, string newName)
        //      {
        //          string result = "Такого отела не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
        //              department.Name = newName;
        //              db.SaveChanges();
        //              result = "Сделано! Отдел " + department.Name + " изменен";
        //          }
        //          return result;
        //      }
        //      //редактирование позицию
        //      public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        //      {
        //          string result = "Такой позиции не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
        //              position.Name = newName;
        //              position.Salary = newSalary;
        //              position.MaxNumber = newMaxNumber;
        //              position.DepartmentId = newDepartment.Id;
        //              db.SaveChanges();
        //              result = "Сделано! Позиция " + position.Name + " изменена";
        //          }
        //          return result;
        //      }
        //      //редактирование сотрудника
        //      public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        //      {
        //          string result = "Такого сотрудника не существует";
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              //check user is exist
        //              User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
        //              if (user != null)
        //              {
        //                  user.Name = newName;
        //                  user.SurName = newSurName;
        //                  user.Phone = newPhone;
        //                  user.PositionId = newPosition.Id;
        //                  db.SaveChanges();
        //                  result = "Сделано! Сотрудник " + user.Name + " изменен";
        //              }
        //          }
        //          return result;
        //      }
        //
        //      //получение позиции по id позитиции
        //      public static Position GetPositionById(int id)
        //      {
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
        //              return pos;
        //          }
        //      }
        //      //получение отдела по id отдела
        //      public static Department GetDepartmentById(int id)
        //      {
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              Department pos = db.Departments.FirstOrDefault(p => p.Id == id);
        //              return pos;
        //          }
        //      }
        //      //получение всех пользователей по id позиции
        //      public static List<User> GetAllUsersByPositionId(int id)
        //      {
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
        //              return users;
        //          }
        //      }
        //      //получение всех позиций по id отдела
        //      public static List<Position> GetAllPositionsByDepartmentId(int id)
        //      {
        //          using (ApplicationContext db = new ApplicationContext())
        //          {
        //              List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
        //              return positions;
        //          }
        //      }
    }
}
