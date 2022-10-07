using ControleFinanceiro.controllers;
using ControleFinanceiro.models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace ControleFinanceiro.views;

/// <summary>
/// Interação lógica para chartColumn.xam
/// </summary>
public partial class ChartColumn : UserControl
{
    private readonly TransactionController controller;
    public ChartColumn(Context context)
    {
        controller = new TransactionController(context);
        InitializeComponent();
        SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Entrada",
                Values = new ChartValues<double>()
            },
            new ColumnSeries
            {
                Title = "Saída",
                Values = new ChartValues<double>()
            }
         };

        PlotChart(DateTime.Now.Year);

        Labels = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
        Formatter = value => value.ToString("N");

        DataContext = this;
    }

    public SeriesCollection SeriesCollection { get; set; }
    public string[] Labels { get; set; }
    public Func<double, string> Formatter { get; set; }

    private void PlotChart(int year)
    {
        for (int i = 1; i <= 12; i++)
        {
            decimal sumOutput = 0, sumInput = 0;
            foreach (Transaction transaction in controller.GetByMonthAndYear(month: i, year: year))
            {
                if (transaction.transactionType == "O")
                    sumOutput += transaction.value;
                else
                    sumInput += transaction.value;
            }
            SeriesCollection[0].Values.Add(((double)sumInput));
            SeriesCollection[1].Values.Add(((double)sumOutput));
        }
    }
}
