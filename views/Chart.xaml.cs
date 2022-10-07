using ControleFinanceiro.controllers;
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

namespace ControleFinanceiro.views;

/// <summary>
/// Interação lógica para Chart.xam
/// </summary>
public partial class Chart : UserControl
{
    private readonly Context context;
    public Chart(Context context)
    {
        this.context = context;
        InitializeComponent();
    }

    private void ColumnChart_Checked(object sender, RoutedEventArgs e)
    {
        DataContext = new ChartColumn(context);
    }
    private void PieChart_Checked(object sender, RoutedEventArgs e)
    {
        DataContext = new ChartPie(context);
    }
    private void BarChart_Checked(object sender, RoutedEventArgs e)
    {
        DataContext = new ChartColumn(context);
    }
}
