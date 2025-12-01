using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static WinUI_Caculator.MainWindow;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Caculator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // 把 ViewModel 設為視窗的 DataContext
            RootGrid.DataContext = new CalculatorViewModel();
            // 把整個 Grid 的資料上下文綁定到 CalculatorViewModel。
            // 這樣 XAML 上的 {Binding DisplayText} 或 {Binding NumberCommand} 就會自動對應到 ViewModel 的屬性和命令。
        }

        public enum Operator { ADD = '+', SUB = '-', MUL = '*', DIV = '/' };

        public static class OperatorHelper
        {
            public static bool TryConvertSymbolToOperator(string symbol, out Operator op)
            {
                switch (symbol)
                {
                    case "+":
                        op = Operator.ADD; return true;
                    case "-":
                        op = Operator.SUB; return true;
                    case "*":
                        op = Operator.MUL; return true;
                    case "/":
                        op = Operator.DIV; return true;
                    default:
                        op = default;
                        return false;
                }
            }
        }

    }
    public partial class CalculatorViewModel : ObservableObject
    {
        // 顯示欄位
        [ObservableProperty]
        private string displayText = "0"; // TextBox 顯示的數字
        [ObservableProperty]
        private string messageText = "";  // 顯示錯誤或提示訊息

        private float firstNumber, secondNumber; // firstNumber 儲存第一個數字，secondNumber 儲存第二個數字
        private Operator? currentOperator = null;    // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

        // 數字按鍵命令，CommandParameter 傳入字串 "0"~"9" 或 "."
        public IRelayCommand<string> NumberCommand { get; }

        // 運算符按鈕命令，CommandParameter 傳入運算符 "+", "-", "*" , "/"
        public IRelayCommand<string> OperatorCommand { get; }

        // 等號命令
        public IRelayCommand EqualCommand { get; }

        // 清除命令
        public IRelayCommand ClearCommand { get; }

        public CalculatorViewModel()
        {
            NumberCommand = new RelayCommand<string>(OnNumberPressed);
            OperatorCommand = new RelayCommand<string>(OnOperatorPressed);
            EqualCommand = new RelayCommand(OnEqualPressed);
            ClearCommand = new RelayCommand(OnClearPressed);
        }

        private void OnNumberPressed(string num)
        {
            if (DisplayText == "0")
                DisplayText = num;
            else
                DisplayText += num;
        }

        private void OnOperatorPressed(string symbol)
        {
            if (!float.TryParse(DisplayText, out firstNumber))
            {
                MessageText = "輸入錯誤";
                return;
            }

            if (OperatorHelper.TryConvertSymbolToOperator(symbol, out var op))
            {
                currentOperator = op;
            }
            else
            {
                MessageText = "運算符錯誤";
                return;
            }
            DisplayText = "0";
        }

        private void OnEqualPressed()
        {
            if (!float.TryParse(DisplayText, out secondNumber))
            {
                MessageText = "輸入錯誤";
                return;
            }

            float result = 0;
            switch (currentOperator)
            {
                case Operator.ADD:
                    result = firstNumber + secondNumber;
                    break;
                case Operator.SUB:
                    result = firstNumber - secondNumber;
                    break;
                case Operator.MUL:
                    result = firstNumber * secondNumber;
                    break;
                case Operator.DIV:
                    if (secondNumber == 0)
                    {
                        MessageText = "除數不可為0";
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
                default:
                    MessageText = "尚未選擇運算符";
                    return;
            }
            DisplayText = result.ToString();
            firstNumber = secondNumber = 0;
            currentOperator = null;
        }

        private void OnClearPressed()
        {
            DisplayText = "0";
            MessageText = "";
            firstNumber = secondNumber = 0;
            currentOperator = null;
        }
    }
}
