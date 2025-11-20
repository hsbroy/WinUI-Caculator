using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Caculator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // 全域變數
        float firstNumber, secondNumber; // firstNumber 儲存第一個數字，secondNumber 儲存第二個數字
        int operators = -1; // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void add_Number(String _number)
        {
            if (textNumber.Text == "0")
                textNumber.Text = "";
            textNumber.Text += _number;
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            add_Number("9");
        }
        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            add_Number("8");
        }
        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            add_Number("7");
        }
        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            add_Number("6");
        }
        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            add_Number("5");
        }
        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            add_Number("4");
        }
        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            add_Number("3");
        }
        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            add_Number("2");
        }
        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            add_Number("1");
        }
        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            add_Number("0");
        }

        private void Select_Operator(int _operator)
        {
            try
            {
                firstNumber = Convert.ToSingle(textNumber.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
                textNumber.Text = "0"; //重新將輸入文字框重新設定為0
                operators = _operator; //選擇「加」號
            }
            catch (FormatException)
            {
                textMessage.Text = "輸入的內容不是數字，請重新輸入。";
            }
            finally
            {
                textNumber.Text = "0";
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(0);
        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(1);
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(2);
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(3);
        }
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float finalResults = 0f; //宣告最後計算結果變數
                secondNumber = Convert.ToSingle(textNumber.Text); //將輸入文字框轉換成浮點數，存入第二個數字的全域變數

                //依照四則運算符號的選擇，進行加減乘除
                switch (operators)
                {
                    case 0:
                        finalResults = firstNumber + secondNumber;
                        break;
                    case 1:
                        finalResults = firstNumber - secondNumber;
                        break;
                    case 2:
                        finalResults = firstNumber * secondNumber;
                        break;
                    case 3:
                        if (secondNumber != 0)
                        {
                            finalResults = firstNumber / secondNumber;
                        }
                        else
                        {
                            textNumber.Text = "Error";
                            textMessage.Text = "錯誤：除數不可為0";
                            return;
                        }
                        break;
                }
                textNumber.Text = string.Format("{0:0.##########}", finalResults); //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容
            }
            catch (FormatException)
            {
                textMessage.Text = "輸入的內容不是數字，請重新輸入。";
                textNumber.Text = "0";
            }
            finally
            {
                //重置所有全域變數
                firstNumber = 0f;
                secondNumber = 0f;
                operators = -1;
            }
        }
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (textNumber.Text.IndexOf(".") == -1)
                textNumber.Text = textNumber.Text + ".";
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textNumber.Text = "0";
            textMessage.Text = "";
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }
    }
}
