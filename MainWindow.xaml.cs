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


namespace ControleFinanceiro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var clientes = new[]{
                  new {Nome = "José Maria", Telefone = "3333-3333", Email = "josemaria@email.com"},
                  new {Nome = "Antonio Carlos", Telefone = "4444-4444", Email = "antonio@email.com"},
                  new {Nome = "Pedro Henrique", Telefone = "5555-5555", Email = "pedro@email.com"},
                  new {Nome = "Augusto Cesar", Telefone = "6666-6666", Email = "augusto@email.com"},
                  new {Nome = "Carlos Silva", Telefone = "7777-7777", Email = "carlos@email.com"}
              };

            TabelaUltimosRegistros.ItemsSource = clientes;
        }

        private BrushConverter bc = new BrushConverter();

        private void IncomeIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            IncomeIcon.Background = (Brush) this.bc.ConvertFrom("#33006400");
        }

        private void IncomeIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            IncomeIcon.Background = new SolidColorBrush(Colors.White);
        }
        private void OutcomeIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            OutcomeIcon.Background = (Brush)this.bc.ConvertFrom("#33FF0000");
        }

        private void OutcomeIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            OutcomeIcon.Background = new SolidColorBrush(Colors.White);
        }
        private void ChartIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            ChartIcon.Background = (Brush)this.bc.ConvertFrom("#33000000");
        }

        private void ChartIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            ChartIcon.Background = new SolidColorBrush(Colors.White);
        }
    }
}
