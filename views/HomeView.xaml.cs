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
    /// Interação lógica para HomeView.xam
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly TransactionController controller;
        public HomeView(Context context)
        {
            controller = new TransactionController(context);
            InitializeComponent();
            var lastItems = controller.GetAll();
            HomeTable.ItemsSource = lastItems.OrderByDescending(i => i.date.Date).ThenByDescending(i => i.date.TimeOfDay).Take(20).ToList();
        }
    }
}
