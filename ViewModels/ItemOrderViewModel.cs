using Keedoozle_Fine_Food.Helpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Keedoozle_Fine_Food.ViewModels
{
    public class ItemOrderViewModel : ViewModelBase
    {
        private const double TAX_PERCENTAGE = 0.03;
        private int id;
        private string? name;
        private int quantiy;
        private double price;
        private int tax;
        public string comments;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();

            }
        }
        public int Quantiy
        {
            get => quantiy;
            set
            {
                quantiy = value;
                OnPropertyChanged();

            }
        }
        public double Price
        {
            get => price; set
            {
                price = value;
                OnPropertyChanged();

            }
        }
        public double Total
        {
            get => price * quantiy;
        }
        public int Tax
        {
            get => tax; set
            {
                tax = value;
                OnPropertyChanged();
            }
        }
        public string Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<AdditionalItem> AdditionalItems { get; set; } = ADO.GetadditionalItemsName();
        public ItemOrderViewModel() { }
        public ItemOrderViewModel(ItemViewModel item)
        {

            Id = item.Id;
            Name = item.Name;
            Quantiy = item.Quantiy;
            Price = item.Total;
            Tax = item.Tax;
        }
        private void AdditionalItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Comments = string.Join(", ", AdditionalItems.ToList().Where(add => add.IsSelected).Select(add => add.Name));
            }
        }

        public double CalcTax()
        {
            return Convert.ToInt32(Tax) * Total * TAX_PERCENTAGE;
        }
    }
}
