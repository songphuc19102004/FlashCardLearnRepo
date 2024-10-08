﻿using System.Windows.Controls;
using System.Windows.Input;

public abstract class CommandBase: ICommand
{
    public event EventHandler CanExecuteChanged;

    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }
    public abstract void Execute(object? parameter);
    
    protected void OnCanExecutedChanged()
    {
        CanExecuteChanged?.Invoke(this, new EventArgs());
    }

    public void RaiseCanExecutedChanged() 
    {
        OnCanExecutedChanged();
    }
}