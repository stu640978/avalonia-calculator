using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaCalculatorApp.ViewModels;

namespace AvaloniaCalculatorApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel)
        {
            switch(e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    viewModel.NumberButtonClickCommand.Execute("0");
                    break;
                
                case Key.D1:
                case Key.NumPad1:
                    viewModel.NumberButtonClickCommand.Execute("1");
                    break;
                
                case Key.D2:
                case Key.NumPad2:
                    viewModel.NumberButtonClickCommand.Execute("2");
                    break;
                
                case Key.D3:
                case Key.NumPad3:
                    viewModel.NumberButtonClickCommand.Execute("3");
                    break;
                
                case Key.D4:
                case Key.NumPad4:
                    viewModel.NumberButtonClickCommand.Execute("4");
                    break;
                
                case Key.D5:
                case Key.NumPad5:
                    viewModel.NumberButtonClickCommand.Execute("5");
                    break;
                
                case Key.D6:
                case Key.NumPad6:
                    viewModel.NumberButtonClickCommand.Execute("6");
                    break;
                
                case Key.D7:
                case Key.NumPad7:
                    viewModel.NumberButtonClickCommand.Execute("7");
                    break;
                
                case Key.D8:
                case Key.NumPad8:
                    viewModel.NumberButtonClickCommand.Execute("8");
                    break;
                
                case Key.D9:
                case Key.NumPad9:
                    viewModel.NumberButtonClickCommand.Execute("9");
                    break;
                
                case Key.Add:
                    viewModel.OperationButtonClickCommand.Execute("+");
                    break;
                
                case Key.Subtract:
                    viewModel.OperationButtonClickCommand.Execute("-");
                    break;
                
                case Key.Multiply:
                    viewModel.OperationButtonClickCommand.Execute("*");
                    break;
                
                case Key.Divide:
                    viewModel.OperationButtonClickCommand.Execute("/");
                    break;
                
                case Key.Decimal:
                    viewModel.NumberButtonClickCommand.Execute(".");
                    break;
                
                case Key.Enter:
                    viewModel.EqualButtonClickCommand.Execute(null);
                    break;
                
                case Key.Back:
                    viewModel.DeleteButtonClickCommand.Execute(null);
                    break;
                
                case Key.Delete:
                    viewModel.ClearButtonClickCommand.Execute(null);
                    break;
            }
        }
    }
}