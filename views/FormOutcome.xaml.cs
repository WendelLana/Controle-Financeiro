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
    public partial class FormOutcome : Window
    {

        private string typeAction = "";
        private OutcomeView parentView;
        private Movimentation modelData;
        public FormOutcome()
        {
            parentView = (OutcomeView)Application.Current.MainWindow.DataContext;
            modelData = parentView.getSelectedOutcome();
            InitializeComponent();
            
        }

        public FormOutcome(string titleLabel, Movimentation data, string type)
        {
            parentView = (OutcomeView)Application.Current.MainWindow.DataContext;
            modelData = data;
            typeAction = type;

            InitializeComponent();
            TitleLabel.Content = titleLabel;
            OutcomeGrid.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
