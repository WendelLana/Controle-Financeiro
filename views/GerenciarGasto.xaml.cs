﻿using System;
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
    public partial class GerenciarGasto : Window
    {

        private string tipoAcao = "";
        private GastosView parentView;
        private MovimentacaoModel modelData;
        public GerenciarGasto()
        {
            parentView = (GastosView)Application.Current.MainWindow.DataContext;
            modelData = parentView.getSelectedGasto();
            InitializeComponent();
            
        }

        public GerenciarGasto(string titleLabel, MovimentacaoModel data, string tipo)
        {
            parentView = (GastosView)Application.Current.MainWindow.DataContext;
            modelData = data;
            tipoAcao = tipo;

            InitializeComponent();
            TitleLabel.Content = titleLabel;
            GastoGrid.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
