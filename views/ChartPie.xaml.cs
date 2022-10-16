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
using LiveCharts;
using LiveCharts.Wpf;
using ControleFinanceiro.controllers;
using ControleFinanceiro.models;

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interaction logic for ChartPie.xaml
    /// </summary>
    public partial class ChartPie : UserControl
    {
        private readonly Context _context;
        private readonly TransactionController _transactionController;
        private readonly CategoryController _categoryController;
        public ChartPie(Context context)
        {
            _context = context;
            _transactionController = new TransactionController(context);
            _categoryController = new CategoryController(context);

            InitializeComponent();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            
            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void CategoryFilter_Checked(object sender, RoutedEventArgs e)
        {
            SeriesCollection seriesEntrada = new SeriesCollection();
            SeriesCollection seriesSaida = new SeriesCollection();

            var yearTransactions = _transactionController.GetAllByYear(DateTime.Now.Year);

            Dictionary<Guid, Category> categoriesDict = new();

            Dictionary<Guid, List<Transaction>> transactionByCategoriesDict = new();

            yearTransactions.ForEach(transaction =>
            {
                if (transactionByCategoriesDict.ContainsKey(transaction.categoryId))
                {
                    transactionByCategoriesDict[transaction.categoryId].Add(transaction);
                } else
                {
                    transactionByCategoriesDict.Add(transaction.categoryId, new List<Transaction> { transaction });
                }

                if (categoriesDict.ContainsKey(transaction.categoryId))
                {
                    categoriesDict[transaction.categoryId] = transaction.Category;
                }
                else
                {
                    categoriesDict.Add(transaction.categoryId, transaction.Category);
                }
            });

            var allCategoriesKeys = categoriesDict.Keys.ToList();

            allCategoriesKeys.ForEach(key =>
            {
                var labelBinding = new Binding("PointLabel");
                var serie = new PieSeries()
                {
                    Title = categoriesDict[key].name,
                    Values = new ChartValues<decimal> { transactionByCategoriesDict[key].Sum(obj => obj.value) },
                    DataLabels = true,
                    Fill = (Brush)new BrushConverter().ConvertFromString(categoriesDict[key].color)
                };
                serie.SetBinding(PieSeries.LabelPointProperty, labelBinding);

                if (categoriesDict[key].transactionType == "I")
                {
                    seriesEntrada.Add(serie);
                } else
                {
                    seriesSaida.Add(serie);
                }
            });

            PieChartEntradaControl.Series = seriesEntrada;
            PieChartSaidaControl.Series = seriesSaida;
        }
        private void MonthFilter_Checked(object sender, RoutedEventArgs e)
        {
            SeriesCollection seriesEntrada = new SeriesCollection();
            SeriesCollection seriesSaida = new SeriesCollection();

            var yearTransactions = _transactionController.GetAllByYear(DateTime.Now.Year);

            Dictionary<int, List<Transaction>> transactionsByMonthEntrada = new();
            Dictionary<int, List<Transaction>> transactionsByMonthSaida = new();

            yearTransactions.ForEach(transaction =>
            {
                if (transaction.transactionType == "I")
                {
                    if (transactionsByMonthEntrada.ContainsKey(transaction.date.Month))
                    {
                        transactionsByMonthEntrada[transaction.date.Month].Add(transaction);
                    }
                    else
                    {
                        transactionsByMonthEntrada.Add(transaction.date.Month, new List<Transaction> { transaction });
                    }
                } else
                {
                    if (transactionsByMonthSaida.ContainsKey(transaction.date.Month))
                    {
                        transactionsByMonthSaida[transaction.date.Month].Add(transaction);
                    }
                    else
                    {
                        transactionsByMonthSaida.Add(transaction.date.Month, new List<Transaction> { transaction });
                    }
                }
                
            });

            var allMonthKeysEntrada = transactionsByMonthEntrada.Keys.ToList();
            var allMonthKeysSaida = transactionsByMonthSaida.Keys.ToList();

            allMonthKeysEntrada.ForEach(key =>
            {
                var labelBinding = new Binding("PointLabel");
                var serie = new PieSeries()
                {
                    Title = GetMonthString(key),
                    Values = new ChartValues<decimal> { transactionsByMonthEntrada[key].Sum(obj => obj.value)},
                    DataLabels = true,
                };

                serie.SetBinding(PieSeries.LabelPointProperty, labelBinding);
                seriesEntrada.Add(serie);
            });

            allMonthKeysSaida.ForEach(key =>
            {
                var labelBinding = new Binding("PointLabel");
                var serie = new PieSeries()
                {
                    Title = GetMonthString(key),
                    Values = new ChartValues<decimal> { transactionsByMonthSaida[key].Sum(obj => obj.value) },
                    DataLabels = true,
                };

                serie.SetBinding(PieSeries.LabelPointProperty, labelBinding);
                seriesSaida.Add(serie);
            });
            PieChartSaidaControl.Series = seriesSaida;
            PieChartEntradaControl.Series = seriesEntrada;
        }

        private string GetMonthString(int month)
        {
            return month switch
            {
                1 => "Janeiro",
                2 => "Fevereiro",
                3 => "Março",
                4 => "Abril",
                5 => "Maio",
                6 => "Junho",
                7 => "Julho",
                8 => "Agosto",
                9 => "Setembro",
                10 => "Outubro",
                11 => "Novembro",
                12 => "Dezembro",
                _ => "",
            };
        }
    }
}
