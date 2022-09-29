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
        Category selectedCategory = new();
        public CategoryView(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetCategories();
        }

        private void GetCategories()
        {
            CategoryDataGrid.ItemsSource = context.Categories.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedCategory = (sender as FrameworkElement).DataContext as Category;
            var formWindow = new FormCategory("Editar Categoria", new Category(selectedCategory), "editar");
            formWindow.Show();
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
            var formWindow = new FormCategory("Cadastrar Categoria", new Category(), "cadastrar");
            formWindow.Show();
        }

        public void EditCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
            GetCategories();
        }

        public void AddCategory(Category NewCategory)
        {
            context.Categories.Add(NewCategory);
            context.SaveChanges();
            GetCategories();
        }
    }
}
