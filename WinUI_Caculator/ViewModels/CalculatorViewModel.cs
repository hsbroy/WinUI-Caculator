using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WinUI_Caculator.ViewModels
{
    public enum Operator { ADD = '+', SUB = '-', MUL = '*', DIV = '/' }

    public partial class CalculatorViewModel : ObservableObject
    {
        // 顯示區文字
        [ObservableProperty]
        private string displayText = "0";

        // 提示訊息
        [ObservableProperty]
        private string messageText = "";

        private float firstNumber, secondNumber;
        private Operator? currentOperator = null;

        // Commands
        public IRelayCommand<string> NumberCommand { get; }
        public IRelayCommand<string> OperatorCommand { get; }
        public IRelayCommand EqualCommand { get; }
        public IRelayCommand ClearCommand { get; }
        public IRelayCommand<string> BaseConversionCommand { get; }
        public IRelayCommand<string> TemperatureCommand { get; }

        public CalculatorViewModel()
        {
            NumberCommand = new RelayCommand<string>(OnNumberPressed);
            OperatorCommand = new RelayCommand<string>(OnOperatorPressed);
            EqualCommand = new RelayCommand(OnEqualPressed);
            ClearCommand = new RelayCommand(OnClearPressed);
            BaseConversionCommand = new RelayCommand<string>(OnBaseConversion);
            TemperatureCommand = new RelayCommand<string>(OnTemperatureConversion);
        }

        private void OnNumberPressed(string num)
        {
            if (num == ".")
            {
                // 如果已經有小數點，就不加
                if (DisplayText.Contains(".")) return;
                DisplayText += ".";
            }
            else
            {
                if (DisplayText == "0")
                    DisplayText = num;
                else
                    DisplayText += num;
            }
        }


        private void OnOperatorPressed(string symbol)
        {
            if (!float.TryParse(DisplayText, out firstNumber))
            {
                MessageText = "輸入錯誤";
                return;
            }

            currentOperator = symbol switch
            {
                "+" => Operator.ADD,
                "-" => Operator.SUB,
                "*" => Operator.MUL,
                "/" => Operator.DIV,
                _ => null
            };

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
                case Operator.ADD: result = firstNumber + secondNumber; break;
                case Operator.SUB: result = firstNumber - secondNumber; break;
                case Operator.MUL: result = firstNumber * secondNumber; break;
                case Operator.DIV:
                    if (secondNumber == 0)
                    {
                        MessageText = "除數不可為 0";
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

        private void OnBaseConversion(string baseType)
        {
            if (!int.TryParse(DisplayText, out int num))
            {
                MessageText = "輸入錯誤";
                return;
            }

            DisplayText = baseType switch
            {
                "BIN" => Convert.ToString(num, 2),
                "OCT" => Convert.ToString(num, 8),
                "DEC" => num.ToString(),
                "HEX" => Convert.ToString(num, 16).ToUpper(),
                _ => DisplayText
            };
        }

        private void OnTemperatureConversion(string mode)
        {
            if (!double.TryParse(DisplayText, out double value))
            {
                MessageText = "輸入錯誤";
                return;
            }

            double result = mode switch
            {
                "C→F" => value * 9 / 5 + 32,
                "F→C" => (value - 32) * 5 / 9,
                "C→K" => value + 273.15,
                _ => value
            };

            DisplayText = result.ToString("F2");
        }
    }
}
