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
using ControleFinanceiro.controllers;
using ControleFinanceiro.models;

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interaction logic for EntradasView.xaml
    /// </summary>
    public partial class IncomeView : UserControl
    {
        private readonly IncomeController controller;

        public IncomeView(Context context)
        {
            controller = new IncomeController(context);
            InitializeComponent();
            GetIncomes();
        }

        private void GetIncomes()
        {
            IncomeTable.ItemsSource = controller.GetAll();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var formWindow = new FormIncome("Cadastrar Entrada", new Transaction(), "cadastrar");
            formWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Transaction selectedIncome = (sender as FrameworkElement).DataContext as Transaction;
            var gerenciarWindow = new FormIncome("Editar Entrada", selectedIncome, "editar");
            gerenciarWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Transaction income = (sender as FrameworkElement).DataContext as Transaction;
            controller.Remove(income);
            GetIncomes();
        }

        public void EditIncome(Transaction income)
        {
            controller.Update(income);
            GetIncomes();
        }

        public void AddIncome(Transaction income)
        {
            income.transactionType = "I";
            controller.Add(income);
            GetIncomes();
        }
    }
}
