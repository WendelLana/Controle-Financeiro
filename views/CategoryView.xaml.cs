using ControleFinanceiro.controllers;
using ControleFinanceiro.models;
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

namespace ControleFinanceiro.views
{
    /// <summary>
    /// Interação lógica para CategoriaView.xam
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private readonly Context context;
        Category NewCategory = new();
        public CategoryView(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetCategories();
            CategoryDataGrid.DataContext = NewCategory;
        }

        private void GetCategories()
        {
            CategoryDataGrid.ItemsSource = context.Categories.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var category = (sender as FrameworkElement).DataContext as Category;
            context.Categories.Remove(category);
            context.SaveChanges();
            GetCategories();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
