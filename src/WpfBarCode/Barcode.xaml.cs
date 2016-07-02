using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : UserControl, INotifyPropertyChanged
    {
        private BarcodeEngine barcodeEngine = null;
        private ObservableCollection<BarcodeItem> barCodeItems = new ObservableCollection<BarcodeItem>()
        {
            new BarcodeItem() { Color = Brushes.Black, Width = 5 },
            new BarcodeItem() { Color = Brushes.White, Width = 5 },
            new BarcodeItem() { Color = Brushes.Black, Width = 5 },
        };
        ObservableCollection<BarcodeItem> BarCodeItems
        {
            get
            {
                return this.barCodeItems;
            }
        }
        public Barcode()
        {
            InitializeComponent();
            barcodeEngine = new BarcodeEngine();
            this.DataContext = barCodeItems;
        }

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register(
            "Code",
            typeof(string),
            typeof(Barcode),
            new UIPropertyMetadata((s, e) =>
        {
            Barcode dp = s as Barcode;
            dp.codeTextBlock.Text = e.NewValue.ToString();
            dp.barCodeItems.Clear();
            dp.barcodeEngine.Generate(e.NewValue.ToString()).ForEach(item => dp.barCodeItems.Add(item));
            dp.RaisePropertyChanged("Code");
        }));

        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public static readonly DependencyProperty CodeTypeProperty = DependencyProperty.Register(
            "CodeType",
            typeof(string),
            typeof(Barcode),
            new PropertyMetadata(BarCodeType.Code39, (s, e) =>
            {
                Barcode dp = s as Barcode;
                dp.CodeType = (string)e.NewValue;
                dp.barcodeEngine.CodeType = (string)e.NewValue;
                dp.barCodeItems.Clear();
                dp.barcodeEngine.Generate(dp.Code).ForEach(item => dp.barCodeItems.Add(item));
                dp.RaisePropertyChanged("CodeType");
                dp.RaisePropertyChanged("Code");
            }));

        public string CodeType
        {
            get { return (string)GetValue(CodeTypeProperty); }
            set { SetValue(CodeTypeProperty, value); }
        }

        public static readonly DependencyProperty Code39WideRateProperty = DependencyProperty.Register(
            "Code39WideRate",
            typeof(double),
            typeof(Barcode),
            new PropertyMetadata(1d, (s, e) =>
            {
                Barcode dp = s as Barcode;
                dp.Code39WideRate = (double)e.NewValue;
                dp.barcodeEngine.Code39WideRate = dp.Code39WideRate;
                dp.barCodeItems.Clear();
                dp.barcodeEngine.Generate(dp.Code).ForEach(item => dp.barCodeItems.Add(item));
                dp.RaisePropertyChanged("Code39WideRate");
            }));

        public double Code39WideRate
        {
            get { return (double)GetValue(Code39WideRateProperty); }
            set { SetValue(Code39WideRateProperty, value); }
        }

        public static readonly DependencyProperty TextVisibilityProperty = DependencyProperty.Register(
            "TextVisibility",
            typeof(Visibility),
            typeof(Barcode),
            new PropertyMetadata(Visibility.Visible, (s, e) =>
            {
                Barcode dp = s as Barcode;
                dp.TextVisibility = (Visibility)e.NewValue;
                dp.RaisePropertyChanged("TextVisibility");
            }));

        public Visibility TextVisibility
        {
            get { return (Visibility)GetValue(TextVisibilityProperty); }
            set { SetValue(TextVisibilityProperty, value); }
        }

        public static readonly DependencyProperty BarWidthProperty = DependencyProperty.Register(
            "BarWidth",
            typeof(double),
            typeof(Barcode),
            new PropertyMetadata(1.5, (s, e) =>
            {
                Barcode dp = s as Barcode;
                dp.BarWidth = (double)e.NewValue;
                dp.barCodeItems.Clear();
                dp.barcodeEngine.BarWidth = (double)e.NewValue;
                dp.barcodeEngine.Generate(dp.Code).ForEach(item => dp.barCodeItems.Add(item));
                dp.RaisePropertyChanged("BarWidth");
            }));

        public double BarWidth
        {
            get { return (double)GetValue(BarWidthProperty); }
            set { SetValue(BarWidthProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
