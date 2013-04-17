using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier5.ViewModel
{
    public class FilteredListViewModel : INotifyPropertyChanged
    {
        private int _selectedFilter = 0;
        private readonly string[] _filters;
        private Model.EntrepriseEntities _context;

        public FilteredListViewModel(Model.EntrepriseEntities context)
        {
            _context = context;
            _filters = "Tout le staff,10$ et moins".Split(',');
        }
        public IEnumerable<object> FilteredList
        {
            get
            {
                switch (this._selectedFilter)
                {
                    case 0:
                        return from employee in _context.Employees
                               select new
                               {
                                   Prénom = employee.First_Name,
                                   Nom = employee.Last_Name
                               };
                    case 1:
                        return from product in _context.Products
                               where product.Unit_Price < 10.0m
                               select new
                               {
                                   Produit = product.Product_Name,
                                   Prix = product.Unit_Price
                               };
                    /* « Anniversaires » qui affiche les jours et les âges des employés dont l’anniversaire est en janvier */
                    case 2:
                        return from employee in _context.Employees
                               where employee.Birth_Date.Value.Month == 1
                               orderby employee.Birth_Date.Value.Year ascending
                               select new
                               {
                                   Jour = employee.Birth_Date.Value.Day,
                                   Age = DateTime.Now.Year - employee.Birth_Date.Value.Year
                               };
                    /* « Commandes françaises » qui affiche pour chaque client Français le nom et le nombre de commandes */
                    case 3:
                        return from order in _context.Orders
                               where order.Ship_Country == "france"
                               select new
                               {
                                   Nom = order.Ship_Name,
                                   Nombre = order.Customer_ID.Count()
                               };


                    default:
                        return new string[] {  
                        "(Not implemented filter)" 
                    };
                }
            }
        }
        public IEnumerable<String> Filters
        {
            get { return _filters; }
        }
        public int SelectedFilter
        {
            get { return this._selectedFilter; }
            set
            {
                this._selectedFilter = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("FilteredList")
                );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
