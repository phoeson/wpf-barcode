using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBarCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> codeTypes = new Dictionary<string, string>()
        {
            { "Code39", "Code39" },
            { "Code128A", "Code128A" },
            { "Code128B", "Code128B" },
            { "Code128C", "Code128C" },
        };
        public MainWindow()
        {
            InitializeComponent();
            codeTypeCombobox.DataContext = codeTypes;
            codeTypeCombobox.SelectedValue = "Code39";
        }

        private void barWithSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            barcode.BarWidth = e.NewValue;
        }

        private void showTextCheckBox_Click(object sender, RoutedEventArgs e)
        {
            barcode.TextVisibility = showTextCheckBox.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void codeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            barcode.Code = codeTextBox.Text;
        }

        private void codeTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            barcode.CodeType = codeTypeCombobox.SelectedValue.ToString();
        }

        private void code39WideBarRateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            barcode.Code39WideRate = e.NewValue;
        }
    }
}
