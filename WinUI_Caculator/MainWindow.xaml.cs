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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


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

        public partial class CalculatorViewModel : ObservableObject
        {
            // 顯示欄位
            [ObservableProperty]
            private string displayText = "0"; // TextBox 顯示的數字
            [ObservableProperty]
            private string messageText = "";  // 顯示錯誤或提示訊息

            private float firstNumber, secondNumber; // firstNumber 儲存第一個數字，secondNumber 儲存第二個數字
            private string? currentOperator; // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

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

            private void OnOperatorPressed(string op)
            {
                if (float.TryParse(DisplayText, out firstNumber))
                {
                    currentOperator = op;
                    DisplayText = "0";
                }
                else
                    MessageText = "輸入錯誤";
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
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageText = "除數不可為0";
                            return;
                        }
                        result = firstNumber / secondNumber;
                        break;
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
}
