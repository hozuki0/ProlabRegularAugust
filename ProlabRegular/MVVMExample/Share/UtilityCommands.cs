using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMExample.Share
{
    public static class UtilityCommands
    {
        public static readonly ICommand CloseCommand =
                new RelayCommand(o => ((Window)o).Close());
    }
}
