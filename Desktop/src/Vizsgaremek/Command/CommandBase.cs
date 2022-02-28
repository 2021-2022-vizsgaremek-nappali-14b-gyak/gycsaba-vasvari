using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace Vizsgaremek.Commands
{
    // https://www.c-sharpcorner.com/UploadFile/e06010/wpf-icommand-in-mvvm/
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
        
    }
}
