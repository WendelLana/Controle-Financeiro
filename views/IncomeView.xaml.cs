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
        private readonly Context context;

        public IncomeView(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetIncomes();
        }

        private void GetIncomes()
        {
            IncomeTable.ItemsSource = context.Incomes.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var formWindow = new FormIncome("Cadastrar Entrada", new Income(), "cadastrar");
            formWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Income selectedIncome = (sender as FrameworkElement).DataContext as Income;
            var gerenciarWindow = new FormIncome("Editar Entrada", selectedIncome, "editar");
            gerenciarWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Income income = (sender as FrameworkElement).DataContext as Income;
            context.Incomes.Remove(income);
            context.SaveChanges();
            GetIncomes();
        }

        public void EditIncome(Income income)
        {
            context.Incomes.Update(income);
            context.SaveChanges();
            GetIncomes();
        }

        public void AddIncome(Income income)
        {
            context.Incomes.Add(income);
            context.SaveChanges();
            GetIncomes();
        }
    }
}
