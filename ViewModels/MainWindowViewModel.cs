using Keedoozle_Fine_Food.Commands;
using Keedoozle_Fine_Food.Helpers;
using Keedoozle_Fine_Food.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace Keedoozle_Fine_Food.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? _currentTime;
        private ItemCategoryViewModel? _SelectedCategory;
        private ItemViewModel? _SelectedItem;
        private ItemOrderViewModel? _SelectedOrderItem;
        private QuantityBoxWindow quantityBoxWindow;
        private OrderViewModel? _Order;
        private bool _IsVisiable;
        public DelegateCommand GetByCategoryCommand { get; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand OpenOrderQunatityDialog { get; }

        public ItemCategoryViewModel? SelectedCategory
        {
            get => _SelectedCategory;
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
                //  GetByCategoryCommand.OnCanExecuteChanged();
                //GetItemsByCategory();


            }
        }
        public OrderViewModel? Order
        {
            get => _Order;
            set
            {
                _Order = value;
                OnPropertyChanged();
                //  GetByCategoryCommand.OnCanExecuteChanged();
                //GetItemsByCategory();


            }
        }
        public ItemViewModel? SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                //ShowQunatity();
            }
        }
        public ItemOrderViewModel? SelectedOrderItem
        {
            get => _SelectedOrderItem;
            set
            {
                _SelectedOrderItem = value;
                OnPropertyChanged();
                ShowAdditionalietms();
            }
        }

        public void ChangeSelected()
        {
            if (SelectedCategory is not null)
                if (Categories is not null)
                {
                    foreach (var item in Categories)
                    {
                        if (item.Id != SelectedCategory.Id)
                        {
                            item.IsSelected = false;
                        }
                    }
                }
        }
        public async Task LoadAsync()
        {

            if (Categories == null)
            {
                return;
            }
            List<ItemCategory> categories = await ADO.GetAllCategories();
            foreach (var item in categories)
            {
                Categories?.Add(new ItemCategoryViewModel()
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                });
            }
            SelectedCategory = Categories.FirstOrDefault();
            if (SelectedCategory is not null)
            {
                SelectedCategory.IsSelected = true;
            }
        }
        public MainWindowViewModel(Window window)
        {
            Order = new OrderViewModel();
            DispatcherTimer timer = new(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    CurrentTime = DateTime.Now.ToString("F");
                }, window?.Dispatcher);

            Items = new ObservableCollection<ItemViewModel>();
            Categories = new ObservableCollection<ItemCategoryViewModel>();
            ItemOrders = new ObservableCollection<ItemOrderViewModel>();
            GetByCategoryCommand = new DelegateCommand(GetItemsByCategory, CanGet);
            OpenOrderQunatityDialog = new DelegateCommand(OpenOrderQunatityWindow, CanShow);
            ClearCommand = new DelegateCommand(Clear, CanClear);
            // OpenDialog = new DelegateCommand(ShowQunatity, CanShow);
        }
        public string? CurrentTime
        {
            get => _currentTime = DateTime.Now.ToString("F");
            set
            {
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ItemViewModel>? Items { get; }
        public ObservableCollection<ItemCategoryViewModel>? Categories { get; }
        public ObservableCollection<ItemOrderViewModel>? ItemOrders { get; }
        public bool IsVisiable { get => _IsVisiable; set { _IsVisiable = value; OnPropertyChanged(); } }

        public async Task GetAllItems()
        {
            List<Item> OrderslIST = (await ADO.GetAllItems());
            foreach (var item in OrderslIST)
            {

                Items?.Add(new ItemViewModel()
                {
                    Id = item.Id,
                    Price = item.Price,
                    Quantiy = item.Quantiy,
                    Name = item.Name,
                    Image = "/images/items/" + ImageUrl(item.ItemCategoryId) + ".png"
                });
            }


        }
        public void CloseOrderQunatityWindow()
        {
            if (quantityBoxWindow != null)
            {
                quantityBoxWindow.Close();
            }
        }
        internal bool CanClear(object? parameter)
        {
            return ItemOrders.Count() > 0;
        }
        internal void Clear(object? parameter)
        {

            Order = new OrderViewModel();
            ItemOrders?.Clear();
            SelectedCategory = Categories?.FirstOrDefault();
            if (SelectedCategory is not null)
            {
                SelectedCategory.IsSelected = true;
            }
        }


        public void ShowAdditionalietms()
        {
            IsVisiable = SelectedOrderItem != null;
        }
        internal void OpenOrderQunatityWindow(object? parameter)
        {
            if (SelectedItem is not null)
            {
                if (SelectedItem.Quantiy == 0)
                {
                    MessageBox.Show("out of quantity ,please choose anthor item", caption: "I'm sorry, we sold out of those.", button: MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                QuantitBoxViewModel quantitBoxViewModel = new(this, SelectedItem);
                quantityBoxWindow = new(quantitBoxViewModel);
                quantityBoxWindow.ShowDialog();
                ClearCommand = new DelegateCommand(Clear, CanClear);
            }
        }
        internal async void GetItemsByCategory(object? parameter)
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.IsSelected = true;
                ChangeSelected();
                Items?.Clear();
                List<Item> ListOfItem;
                if (SelectedCategory.CategoryName != null && SelectedCategory.CategoryName.Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    ListOfItem = (await ADO.GetAllItems());

                }
                else
                {
                    ListOfItem = (await ADO.GetItemsByCategoryId(SelectedCategory.Id));

                }
                foreach (var item in ListOfItem)
                {

                    Items?.Add(new ItemViewModel()
                    {
                        Id = item.Id,
                        Price = item.Price,
                        Quantiy = item.Quantiy,
                        Name = item.Name,
                        Tax = item.Tax,
                        Image = "/images/items/" + ImageUrl(item.ItemCategoryId) + ".png"
                    });
                }
            }


        }

        internal bool CanGet(object? parameter)
        {
            return SelectedCategory != null;
        }
        internal bool CanShow(object? parameter)
        {
            return SelectedItem != null;
        }

        private string? ImageUrl(int categroyId)
        {
            return Categories?.Where(c => c.Id == categroyId).Select(c => c.CategoryName).FirstOrDefault();

        }

        public void UpdateOrderInfo()
        {
            if (ItemOrders is not null && Order is not null)
            {
                Order.SubTotal = ItemOrders.Select(item => item.Total).Sum();

                Order.Tax = ItemOrders.Select(item => item.CalcTax()).Sum();
                Order.Tax = Convert.ToDouble(string.Format("{0:0.##}", Order.Tax));// to convert to 2 decimal point number
                Order.GrandTotal = (Order.SubTotal + Order.Tax);
                Order.GrandTotal -= (Order.Discount / 100 * Order.GrandTotal);
                Order.GrandTotal = Convert.ToDouble(string.Format("{0:0.##}", Order.GrandTotal));
            }

        }
    }
}

