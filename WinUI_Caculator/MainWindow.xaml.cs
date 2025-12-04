using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUI_Calculator.Views;
using WinUI_Calculator.ViewModels;

namespace WinUI_Calculator
{
    public sealed partial class MainWindow : Window
    {
        public CalculatorViewModel ViewModel { get; } = new();

        public MainWindow()
        {
            InitializeComponent();

            // 預設模式：加減乘除
            ModeContent.Content = new CalculatorView { DataContext = ViewModel };
        }

        private void ModeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModeList.SelectedItem is not ListBoxItem item) 
                return;

            switch (item.Content.ToString())
            {
                case "加減乘除":
                    ModeContent.Content = new CalculatorView { DataContext = ViewModel };
                    break;
                        
                case "進制轉換":
                    ModeContent.Content = new BaseConversionView { DataContext = ViewModel };
                    break;

                case "溫度轉換":
                    ModeContent.Content = new TemperatureView { DataContext = ViewModel };
                    break;
            }
        }
    }
}
