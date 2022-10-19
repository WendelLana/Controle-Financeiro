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
using Bogus;

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interação lógica para GastosView.xam
    /// </summary>
    public partial class OutcomeView : UserControl
    {

        private readonly OutcomeController controller;

        public OutcomeView(Context context)
        {
            controller = new OutcomeController(context);

            InitializeComponent();
            GetOutcomes();
        }

        private void GetOutcomes()
        {
            OutcomeTable.ItemsSource = controller.GetAll().OrderByDescending(o => o.date);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var formWindow = new FormOutcome("Cadastrar Gasto", new Transaction(), "cadastrar");
            formWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Transaction? selectedOutcome = (sender as FrameworkElement).DataContext as Transaction;
            var formWindow = new FormOutcome("Editar Gasto", selectedOutcome, "editar");
            formWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var outcome = (sender as FrameworkElement).DataContext as Transaction;
            controller.Remove(outcome);
            GetOutcomes();
        }

        public void EditOutcome(Transaction outcome)
        {
            controller.Update(outcome);
            GetOutcomes();
        }

        public void AddOutcome(Transaction outcome)
        {
            outcome.transactionType = "O";
            controller.Add(outcome);
            GetOutcomes();
        }

        public OutcomeController GetOutcomeController()
        {
            return controller;
        }
    }
}
