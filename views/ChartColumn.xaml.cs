using ControleFinanceiro.controllers;
using ControleFinanceiro.models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ControleFinanceiro.views;

/// <summary>
/// Interação lógica para chartColumn.xam
/// </summary>
public partial class ChartColumn : UserControl
{
    private readonly TransactionController controller;
    private readonly OutcomeController outController;
    public ChartColumn(Context context)
    {
        controller = new TransactionController(context);
        outController = new OutcomeController(context);
        InitializeComponent();
        SeriesCollection = new();

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
        var list = controller.GetAllByYear(year: DateTime.Now.Year);
        var categories = outController.GetAvailableCategories();
        foreach (var cat in categories)
        {
            ChartValues<double> monthOutput = new();
            for (int i = 0; i < 12; i++)
            {
                monthOutput.Insert(i, 0);
                
            }

            list.Where(obj => obj.transactionType == "O" && obj.categoryId == cat.id)
                .Select(s => new
                {
                    Month = s.date.Month,
                    Value = s.value
                })
                .GroupBy(g => g.Month)
                .Select(s => new
                {
                    Month = s.First().Month,
                    value = (double)s.Sum(x => x.Value)
                })
                .ToList()
                .ForEach(item =>
                {
                    monthOutput.Insert(item.Month - 1, item.value);
                });

            SeriesCollection.Add(new ColumnSeries
            {
                Title = cat.name,
                Values = monthOutput
            });
        }
    }
}
