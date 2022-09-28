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
using ControleFinanceiro.controllers;

namespace ControleFinanceiro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        public Decimal balance { get; set; }

        public void updateBalanceText()
        {
            SaldoText.Text = $"R${string.Format("{0:#.00}", Convert.ToDecimal(this.balance))}";
        }
        public MainWindow(Context context)
        {
            this.context = context;
            CultureInfo culture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            
            this.balance = 25.5M;
            InitializeComponent();
            DataContext = new HomeView();
            
            updateBalanceText();
        }
        private void HomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeView();
        }

        private void CategoryIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new CategoryView(context);
        }

        private void OutcomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new OutcomeView(context);
        }

        private void IncomeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new IncomeView(context);
        }
    }
}
