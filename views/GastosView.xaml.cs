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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControleFinanceiro.controllers;
using ControleFinanceiro.models;
using Bogus;

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interação lógica para GastosView.xam
    /// </summary>
    public partial class GastosView : UserControl
    {
        GastoController controller = new GastoController();

        MovimentacaoModel selectedGasto = new MovimentacaoModel();

        public GastosView()
        {
            InitializeComponent();
            var dados = controller.readFakeValues();
            GastosTable.ItemsSource = dados;
        }

        public MovimentacaoModel getSelectedGasto()
        {
            return selectedGasto;
        }

        private void CadastrarBtn_Click(object sender, RoutedEventArgs e)
        {
            var gerenciarWindow = new GerenciarGasto("Cadastrar Gasto", new MovimentacaoModel(), "cadastrar");
            gerenciarWindow.Show();
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedGasto = (sender as FrameworkElement).DataContext as MovimentacaoModel;
            var gerenciarWindow = new GerenciarGasto("Editar Gasto", new MovimentacaoModel(selectedGasto), "editar");
            gerenciarWindow.Show();
        }

        private void RemoverBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedGasto = (sender as FrameworkElement).DataContext as MovimentacaoModel;

        }
    }
}
