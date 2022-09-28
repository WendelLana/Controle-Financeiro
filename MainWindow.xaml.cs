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
using System.Diagnostics;
using ControleFinanceiro.views;
using System.Globalization;
using System.Threading;


namespace ControleFinanceiro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Decimal saldo { get; set; }

        public void atualizaSaldoText()
        {
            SaldoText.Text = $"R${string.Format("{0:#.00}", Convert.ToDecimal(this.saldo))}";
        }
        public MainWindow()
        {
            CultureInfo culture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            
            this.saldo = 25.5M;
            InitializeComponent();
            DataContext = new HomeView();
            
            atualizaSaldoText();
        }

        private void OutcomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new GastosView();
        }

        private void HomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeView();
        }

        private void IncomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new EntradasView();
        }
    }
}
