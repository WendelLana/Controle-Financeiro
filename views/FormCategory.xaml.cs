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
using FontAwesome.WPF;
using MahApps.Metro.IconPacks;

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
            var availableIcons = CategoryController.GetAvailableCategoriesMahIcons();
            parentView = (CategoryView)Application.Current.MainWindow.DataContext;
            typeAction = type;

            InitializeComponent();
            TitleLabel.Content = titleLabel;
            CategoryGrid.DataContext = data;

            // Coloca as opções de tipo de transação
            transactionTypeComboBox.SelectedValuePath = "Key";
            transactionTypeComboBox.DisplayMemberPath = "Value";
            transactionTypeComboBox.Items.Add(new KeyValuePair<string, string>("I", "Entrada"));
            transactionTypeComboBox.Items.Add(new KeyValuePair<string, string>("O", "Saída"));

            // Instancia todas as opções de ícones e faz o bind com o valor do seletor de cor
            availableIcons.ToList().ForEach(val =>
            {
                var comboBoxItem = new ComboBoxItem();
                var itemContent = new StackPanel { Orientation = Orientation.Horizontal };

                PackIconBase icon;
                Binding binding = new Binding("color");

                switch (val.pack)
                {
                    case "PackIconMaterial":
                        icon = new PackIconMaterial()
                        {
                            Kind = (PackIconMaterialKind)Enum.Parse(typeof(PackIconMaterialKind), val.icon),
                            Width = 25,
                            Height = 25,
                        };
                        break;
                        default : icon = new PackIconMaterial();break;
                }
                icon.SetBinding(PackIconBase.ForegroundProperty, binding);
                itemContent.Children.Add(icon);

                comboBoxItem.Content = itemContent;
                IconsComboBox.Items.Add(comboBoxItem);

                if (type == "editar")
                {
                    transactionTypeComboBox.SelectedValue = data.transactionType;
                    var index = availableIcons.ToList().FindIndex(i => i.icon == data.icon && i.pack == data.pack);
                    IconsComboBox.SelectedIndex = index;
                }
            });
        }

        private void ConfirmBtn(object sender, RoutedEventArgs e)
        {
            if (CatName.Text.Length == 0)
            {
                MessageBox.Show("Nome é obrigatório!", "Alerta", MessageBoxButton.OK);
                return;
            }
            var selectedIndex = IconsComboBox.SelectedIndex;
            var selectedIcon = CategoryController.GetAvailableCategoriesMahIcons().ToList()[selectedIndex];
            var selectedtransactionType = transactionTypeComboBox.SelectedValue.ToString();

            if (typeAction.Equals("cadastrar"))
            {
                Category newCategory = CategoryGrid.DataContext as Category;
                newCategory.icon = selectedIcon.icon;
                newCategory.pack = selectedIcon.pack;
                newCategory.transactionType = selectedtransactionType;

                parentView.AddCategory(newCategory);
            } else if (typeAction.Equals("editar"))
            {
                Category editCategory = CategoryGrid.DataContext as Category;
                editCategory.icon = selectedIcon.icon;
                editCategory.pack = selectedIcon.pack;
                editCategory.transactionType = selectedtransactionType;
                parentView.EditCategory(editCategory);
            } else
            {
                //error
            }
            Close();
        }
    }
}
