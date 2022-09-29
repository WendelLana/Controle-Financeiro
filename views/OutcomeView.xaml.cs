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
        private readonly Context context;

        public OutcomeView(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetOutcomes();
        }

        private void GetOutcomes()
        {
            OutcomeTable.ItemsSource = context.Outcomes.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var formWindow = new FormOutcome("Cadastrar Gasto", new Outcome(), "cadastrar");
            formWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Outcome? selectedOutcome = (sender as FrameworkElement).DataContext as Outcome;
            var formWindow = new FormOutcome("Editar Gasto", selectedOutcome, "editar");
            formWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var outcome = (sender as FrameworkElement).DataContext as Outcome;
            context.Outcomes.Remove(outcome);
            context.SaveChanges();
            GetOutcomes();
        }

        public void EditOutcome(Outcome outcome)
        {
            context.Outcomes.Update(outcome);
            context.SaveChanges();
            GetOutcomes();
        }

        public void AddOutcome(Outcome outcome)
        {
            context.Outcomes.Add(outcome);
            context.SaveChanges();
            GetOutcomes();
        }
    }
}
