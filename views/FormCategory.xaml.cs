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
    /// Interação lógica para FormCategory.xam
    /// </summary>
    public partial class FormCategory : Window
    {
        private string typeAction = "";
        private CategoryView parentView;

        public FormCategory(string titleLabel, Category data, string type)
        {   
            parentView = (CategoryView)Application.Current.MainWindow.DataContext;
            typeAction = type;

            InitializeComponent();
            TitleLabel.Content = titleLabel;
            CategoryGrid.DataContext = data;
        }

        private void ConfirmBtn(object sender, RoutedEventArgs e)
        {
            if (typeAction.Equals("cadastrar"))
            {
                Category newCategory = CategoryGrid.DataContext as Category;
                parentView.AddCategory(newCategory);
            } else if (typeAction.Equals("editar"))
            {
                Category editCategory = CategoryGrid.DataContext as Category;
                parentView.EditCategory(editCategory);
            } else
            {
                //error
            }
            Close();
        }
    }
}
