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
        IncomeController controller = new IncomeController();

        Movimentation selectedIncome = new Movimentation();

        public IncomeView()
        {
            InitializeComponent();
            var dados = controller.readFakeValues();
            IncomeTable.ItemsSource = dados;
        }

        public Movimentation getSelectedIncome()
        {
            return selectedIncome;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var gerenciarWindow = new FormIncome("Cadastrar Entrada", new Movimentation(), "cadastrar");
            gerenciarWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedIncome = (sender as FrameworkElement).DataContext as Movimentation;
            var gerenciarWindow = new FormIncome("Editar Entrada", new Movimentation(selectedIncome), "editar");
            gerenciarWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedIncome = (sender as FrameworkElement).DataContext as Movimentation;

        }
    }
}
