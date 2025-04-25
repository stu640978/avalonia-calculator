using System;
using System.Globalization;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaCalculatorApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    /**
     * <summary>顯示算式</summary>
     */
    [ObservableProperty]
    private string _display = "0";

    /**
     * <summary>運算符號</summary>
     */
    [ObservableProperty]
    private string _operation = string.Empty;

    /**
     * <summary>第一個運算元</summary>
     */
    [ObservableProperty]
    private double _firstOperand;

    /**
     * <summary>第二個運算元</summary>
     */
    [ObservableProperty]
    private double _secondOperand;
    
    /**
     * <summary>結果</summary>
     */
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanShowResult))]
    private string _result = string.Empty;

    /**
     * <summary>顯示結果</summary>
     */
    public bool CanShowResult => !string.IsNullOrEmpty(Result);
    
    

    /**
     * <summary>數字按鈕點擊事件</summary>
     */
    [RelayCommand]
    private void OnNumberButtonClick(string number)
    {
        if (Display == "0")
        {
            Display = number;
        }
        else
        {
            Display += number;
        }
    }

    /**
     * <summary>運算符按鈕點擊事件</summary>
     */
    [RelayCommand]
    private void OnOperationButtonClick(string operation)
    {
        // 檢查是否有運算符號且並不在最後一個字元
        var operationIndex = Display.IndexOfAny(['+', '-', '*', '/', '%']);
        if (operationIndex != -1 && operationIndex != Display.Length - 1)
        {
            // 如果有運算符號，則先計算結果
            var result = Calculate(operationIndex);
            Display = result.ToString(CultureInfo.InvariantCulture);
        }

        FirstOperand = double.Parse(Display);
        Operation = operation;
        
        // 確認當前是否已經有運算符號，如果有則替換
        var lastChar = Display.Last();
        if (lastChar is '+' or '-' or '*' or '/' or '%')
        {
            Display = Display.Substring(0, Display.Length - 1) + operation;
        }
        else
        {
            Display += operation;
        }
    }

    /**
     * <summary>等號按鈕點擊事件</summary>
     */
    [RelayCommand]
    private void OnEqualButtonClick()
    {
        // check if operation is empty
        if (string.IsNullOrEmpty(Operation))
        {
            return;
        }
        
        // check second operand after operation by cutting the display string
        var operationIndex = Display.IndexOf(Operation, StringComparison.Ordinal);
        var result = Calculate(operationIndex);

        Result = result.ToString(CultureInfo.InvariantCulture);
        Operation = string.Empty;
    }

    /**
     * <summary>計算結果</summary>
     */
    private double Calculate(int operationIndex)
    {
        SecondOperand = double.Parse(Display.Substring(operationIndex + Operation.Length));

        return Operation switch
        {
            "+" => FirstOperand + SecondOperand,
            "-" => FirstOperand - SecondOperand,
            "*" => FirstOperand * SecondOperand,
            "/" => FirstOperand / SecondOperand,
            "%" => FirstOperand % SecondOperand,
            _ => 0
        };
    }

    /**
     * <summary>清除按鈕點擊事件</summary>
     */
    [RelayCommand]
    private void OnClearButtonClick()
    {
        Display = "0";
        Operation = string.Empty;
        Result = string.Empty;
        FirstOperand = 0;
        SecondOperand = 0;
    }
    
    /**
     * <summary>刪除按鈕點擊事件</summary>
     */
    [RelayCommand]
    private void OnDeleteButtonClick()
    {
        if (Display.Length > 1)
        {
            Display = Display.Substring(0, Display.Length - 1);
        }
        else
        {
            Display = "0";
        }
    }
}