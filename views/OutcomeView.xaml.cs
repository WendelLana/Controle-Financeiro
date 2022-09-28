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
        OutcomeController controller = new OutcomeController();

        Movimentation selectedOutcome = new Movimentation();

        public OutcomeView()
        {
            InitializeComponent();
            var dados = controller.readFakeValues();
            GastosTable.ItemsSource = dados;
        }

        public Movimentation getSelectedOutcome()
        {
            return selectedOutcome;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var gerenciarWindow = new FormOutcome("Cadastrar Gasto", new Movimentation(), "cadastrar");
            gerenciarWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedOutcome = (sender as FrameworkElement).DataContext as Movimentation;
            var gerenciarWindow = new FormOutcome("Editar Gasto", new Movimentation(selectedOutcome), "editar");
            gerenciarWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedOutcome = (sender as FrameworkElement).DataContext as Movimentation;

        }
    }
}
