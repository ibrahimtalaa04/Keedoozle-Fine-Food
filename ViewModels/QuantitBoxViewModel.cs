using Keedoozle_Fine_Food.Commands;
using System.Linq;

namespace Keedoozle_Fine_Food.ViewModels
{
    public class QuantitBoxViewModel : ViewModelBase
    {
        private int availableQuantity;
        private int Id;
        private string? quantity;
        private bool isEnabled;
        private string error;
        public DelegateCommand AddToListCommand { get; }
        public DelegateCommand CheckQuantityCommmand { get; }
        public DelegateCommand CloseOrderQunatityDialog { get; }

        public MainWindowViewModel _mainWindowViewModel { get; set; }
        public QuantitBoxViewModel(MainWindowViewModel mainWindowViewModel, ItemViewModel item)
        {
            AvailableQuantity = item.Quantiy;
            Id = item.Id;
            _mainWindowViewModel = mainWindowViewModel;
            AddToListCommand = new DelegateCommand(AddItemToList);
            CheckQuantityCommmand = new DelegateCommand(CheckQuantity);
            CloseOrderQunatityDialog = new DelegateCommand(CloseOrderQunatityWindow);

        }

        internal void AddItemToList(object? parameter)
        {
            var item = _mainWindowViewModel.Items?.FirstOrDefault(item => item.Id == Id);
            if (item != null)
            {

                var orderitem = _mainWindowViewModel.ItemOrders?.FirstOrDefault(item => item.Id == Id);
                if (orderitem is null)
                {
                    item.Quantiy -= Convert.ToInt32(Quantity);
                    AvailableQuantity = item.Quantiy;

                    _mainWindowViewModel.ItemOrders?.Add(new ItemOrderViewModel()
                    {
                        Quantiy = Convert.ToInt32(Quantity),
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Tax = item.Tax,


                    });
                }
                else
                {
                    item.Quantiy -= Convert.ToInt32(Quantity);
                    AvailableQuantity = item.Quantiy;
                    orderitem.Quantiy += Convert.ToInt32(Quantity);

                }

                _mainWindowViewModel.UpdateOrderInfo();

                CheckQuantity(null);


            }
        }

        public string? Quantity
        {
            get => quantity; set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }


        internal void CheckQuantity(object? paramer)
        {
            if (AvailableQuantity == 0)
            {
                Error = "out of quantity ,please choose anthor item";
                IsEnabled = false;
                if (MessageBox.Show("out of quantity ,please choose anthor item", caption: "I'm sorry, we sold out of those.", button: MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    _mainWindowViewModel.CloseOrderQunatityWindow();
                }
                return;
            }
            IsEnabled = true;
            Error = "";
            bool isnum = int.TryParse(Quantity, out int qun);
            if (isnum)
            {
                if (qun <= 0)
                {
                    Error = "Must Enter Integer Value (greater than zero)";
                    IsEnabled = false;
                }
                else if (qun > AvailableQuantity)
                {
                    Error = $"{Quantity} Items are not available";
                    IsEnabled = false;
                }
            }
            else
            {
                IsEnabled = false;
                Error = "Enter a valid number";

            }
        }
        internal void CloseOrderQunatityWindow(object? parameter)
        {
            _mainWindowViewModel.CloseOrderQunatityWindow();
        }

        public int AvailableQuantity
        {
            get => availableQuantity; set
            {
                availableQuantity = value;

                OnPropertyChanged();
            }
        }

        public string Error
        {
            get => error; set
            {
                error = value;
                OnPropertyChanged();

            }
        }
        public bool IsEnabled
        {
            get => isEnabled; set
            {
                isEnabled = value;
                OnPropertyChanged();

            }
        }

        public void UpdateQuantity()
        {

            throw new NotImplementedException();
        }
    }
}
