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
using System.Windows.Shapes;
using ControleFinanceiro.models;

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interaction logic for GerenciarGasto.xaml
    /// </summary>
    public partial class FormIncome : Window
    {

        private string typeAction = "";
        private IncomeView parentView;
        private Movimentation modelData;
        public FormIncome()
        {
            parentView = (IncomeView)Application.Current.MainWindow.DataContext;
            modelData = parentView.getSelectedIncome();
            InitializeComponent();
            
        }

        public FormIncome(string titleLabel, Movimentation data, string type)
        {
            parentView = (IncomeView)Application.Current.MainWindow.DataContext;
            modelData = data;
            typeAction = type;

            InitializeComponent();
            TitleLabel.Content = titleLabel;
            IncomeGrid.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
