﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RPN
{
    class SimpleAction : ICommand
    {
         private Action _action;
    private bool _canExecute;
    public SimpleAction(Action action, bool canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute;
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
        _action();
    }
    }
}
