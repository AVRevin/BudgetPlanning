using CV19.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands
{
  //  internal class RelayCommand : ICommand
  //  {
  //      private readonly Action<object> _Execute;
  //      private readonly Func<object, bool> _CanExecute;
  //
  //
  //      public event EventHandler CanExecuteChanged;
  //
  //      public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
  //      {
  //          _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
  //          _CanExecute = CanExecute;
  //      }
  //
  //      public bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
  //      
  //      public void Execute(object parameter) => _Execute(parameter);
  //      
  //  }
}
