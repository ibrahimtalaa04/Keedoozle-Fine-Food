namespace Keedoozle_Fine_Food.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private int _orderId;
        private double _discount;
        private double _subTotal;
        private double _tax;
        private double _grandTotal;
        private DateTime _dateCreated;

        public int OrderId { get => _orderId; set { _orderId = value; OnPropertyChanged(); } }
        public double Discount { get => _discount; set { _discount = value; OnPropertyChanged(); } }
        public double SubTotal { get => _subTotal; set { _subTotal = value; OnPropertyChanged(); } }
        public double Tax { get => _tax; set { _tax = value; OnPropertyChanged(); } }
        public double GrandTotal { get => _grandTotal; set { _grandTotal = value; OnPropertyChanged(); } }
        public DateTime DateCreated { get => _dateCreated; set { _dateCreated = value; OnPropertyChanged(); } }
    }
}
