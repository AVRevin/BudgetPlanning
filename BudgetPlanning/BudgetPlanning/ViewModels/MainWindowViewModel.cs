using BudgetPlanning.Commands;
using BudgetPlanning.Data;
using BudgetPlanning.Model;
using BudgetPlanning.Model.Data;
using BudgetPlanning.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BudgetPlanning.ViewModels
{

    internal class MainWindowViewModel : ViewModel
    {
        #region Все категории доходов и расходов
        
        // все категории доходов
        private List<Earning> allCategoryEarnings = DataWorker.GetAllCategoryEarnings();
        public List<Earning> AllCategoryEarnings
        {
            get { return allCategoryEarnings; }
            set { allCategoryEarnings = value; }
        }
        // все категории расходов
        private List<Expense> allCategoryExpenses = DataWorker.GetAllCategoryExpenses();
        public List<Expense> AllCategoryExpenses
        {
            get { return allCategoryExpenses; }
            set { allCategoryExpenses = value; }
        }

        #endregion

        #region Все операции доходов и расходов

        // все операции доходов

        private List<OperationEarning> allOperationEarnings = DataWorker.GetAllOperationEarnings();
        public List<OperationEarning> AllOperationEarnings
        {
            get { return allOperationEarnings; }
            set { allOperationEarnings = value; }
        }

        // все операции расходов
        private  List<OperationExpense> allOperationExpenses = DataWorker.GetAllOperationExpenses();
        public List<OperationExpense> AllOperationExpenses
        {
            get { return allOperationExpenses; }
            set { allOperationExpenses = value; }
        }


        #endregion


        #region Все свойства

        // свойство категории дохода
        public string EarningCategory { get; set; }

        // свойство категории расхода
        public string ExpenseCategory { get; set; }

        // свойства операций
        public Earning Earning { get; set; }

        public Expense Expense { get; set; }

        public decimal Amount { get; set; }

        public DateTime OperationDate { get; set; }

        public string Comments { get; set; }


        //свойства для выделенных элементов
       // public TabItem SelectedTabItem { get; set; }
        public static OperationEarning SelectedOperationEarning { get; set; }
        public static OperationExpense SelectedOperationExpense { get; set; }
        public static Earning SelectedEarning { get; set; }
        public static Expense SelectedExpense { get; set; }


        #endregion


        #region Команды
        private RelayCommand addCategoryEarning;
        public RelayCommand AddCategoryEarning
        {
            get
            {
                return addCategoryEarning ?? new RelayCommand(e =>
                {
                    Window window = e as Window;
                    if (EarningCategory != null)
                    {
                        var resultStr = DataWorker.CreateEarningCategory(EarningCategory);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        window.Close();
                    }
                });
            }
        }


        private RelayCommand addCategoryExpense;
        public RelayCommand AddCategoryExpense
        {
            get
            {
                return addCategoryExpense ?? new RelayCommand(e =>
                {
                    Window window = e as Window;
                    if (ExpenseCategory != null)
                    {
                        var resultStr = DataWorker.CreateExpenseCategory(ExpenseCategory);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        window.Close();
                    }
                });
            }
        }



        #endregion


        #region
        private void AddEaring(object sender,RoutedEvent e)
        {
            
        }

        #endregion

        public MainWindowViewModel()
        {
            #region Команды
            

            #endregion
        }



        private void SetNullValuesToProperties()
        {
            //для категорий
            EarningCategory = null;
            ExpenseCategory = null;
            //для операций
            Amount = 0;
            OperationDate = default(DateTime);
            Comments = null;

        }
        private void UpdateAllDataView()
        {
            UpdateAllOperationEarningView();
            UpdateAllOperationExpensesView();
        }

        private void UpdateAllOperationEarningView()
        {
            AllOperationEarnings = DataWorker.GetAllOperationEarnings();
            MainPage.AllOperationEarningsView.ItemsSource = null;
            MainPage.AllOperationEarningsView.Items.Clear();
            MainPage.AllOperationEarningsView.ItemsSource = AllOperationEarnings;
        }
        private void UpdateAllOperationExpensesView()
        {
            AllCategoryExpenses = DataWorker.GetAllCategoryExpenses();
            MainPage.AllOperationEarningsView.ItemsSource = null;
            MainPage.AllOperationEarningsView.Items.Clear();
            MainPage.AllOperationEarningsView.ItemsSource = AllOperationExpenses;
        }

        private void ReadWindowControll(Window window,string panel)
        {

        }

    }
}
