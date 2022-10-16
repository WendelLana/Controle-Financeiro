using ControleFinanceiro.controllers;
using ControleFinanceiro.models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControleFinanceiro.views;

/// <summary>
/// Interação lógica para ChartLine.xam
/// </summary>
public partial class ChartLine : UserControl
{
    private readonly TransactionController controller;
    public ChartLine(Context context)
    {
        this.controller = new TransactionController(context);
        InitializeComponent();

        SeriesCollection = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Gastos",
                Values = new ChartValues<double>()
            }
        };

        var list = controller.GetAllByYear(year: DateTime.Now.Year);

        List<string> labels = new();
        list.Where(obj => obj.transactionType == "O")
        .Select(t => new
        {
            Parsed = String.Concat(t.date.Day, "/", t.date.Month),
            Value = t.value,
        })
        .OrderBy(t => t.Parsed)
        .GroupBy(g => g.Parsed)
        .Select(s => new
        {
            date = s.First().Parsed,
            value = (double)s.Sum(x => x.Value)
        })
        .ToList()
        .ForEach(item => { SeriesCollection[0].Values.Add(item.value); labels.Add(item.date); });
        
        Labels = labels.ToArray();
        
        YFormatter = value => value.ToString("C");
        DataContext = this;
    }

    public SeriesCollection SeriesCollection { get; set; }
    public string[] Labels { get; set; }
    public Func<double, string> YFormatter { get; set; }

}
