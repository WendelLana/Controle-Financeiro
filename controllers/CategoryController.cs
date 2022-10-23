using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.models;
using System.Collections.ObjectModel;

namespace ControleFinanceiro.controllers
{
    public class CategoryController
    {
        protected readonly Context _context;
        private readonly MainWindow _mainWindow;
        public CategoryController(Context context)
        {
            _context = context;
            _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(Guid id)
        {
            return _context.Categories.FirstOrDefault(obj => obj.id == id);
        }

        public bool Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            _mainWindow.updateBalanceText();
            return true;
        }

        public bool Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return true;
        }

        public static ObservableCollection<IconOption> GetAvailableCategoriesMahIcons()
        {
            return new ObservableCollection<IconOption>()
            {
                new IconOption("PackIconMaterial", "GasStation"),
                new IconOption("PackIconMaterial", "Hanger"),
                new IconOption("PackIconMaterial", "FoodForkDrink"),
                new IconOption("PackIconMaterial", "Car"),
                new IconOption("PackIconMaterial", "School"),
                new IconOption("PackIconMaterial", "Soccer"),
                new IconOption("PackIconMaterial", "Home"),
                new IconOption("PackIconMaterial", "CreditCardOutline"),
                new IconOption("PackIconMaterial", "Heart"),
                new IconOption("PackIconMaterial", "Bus"),
                new IconOption("PackIconMaterial", "Asterisk"),
                new IconOption("PackIconMaterial", "Hamburger"),
            };
        }

        public class IconOption
        {
            public string icon { get; set; }
            public string pack { get; set; }

            public IconOption(string pack, string icon)
            { 
                this.pack = pack;
                this.icon = icon;  
            }
        }
    }
}
