using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetPlanning.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object,bool> canExecute;



        private readonly Action RaiseCanExecuteChangedAction;
        public event EventHandler CanExecuteChanged;


        public RelayCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute is null.");

            this.execute = execute;
            this.canExecute = canExecute;
            this.RaiseCanExecuteChangedAction = RaiseCanExecuteChanged;
            CommandManager.AddRaiseCanExecuteChangedAction(ref RaiseCanExecuteChangedAction);
        }

        ~RelayCommand()
        {
            RemoveCommand();
        }

        public void RemoveCommand()
        {
            CommandManager.RemoveRaiseCanExecuteChangedAction(RaiseCanExecuteChangedAction);
        }

   

        public void Execute(object parameter)
        {
            execute(parameter);
            CommandManager.RefreshCommandStates();
        }
      

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter); 
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

       
    }
}
