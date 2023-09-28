namespace Keedoozle_Fine_Food.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int id;
        private string? name;
        private int quantiy;
        private int categroyId;
        private double price;
        private string? image;
        private int tax;
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
        public int CategroyId
        {
            get => categroyId; set
            {
                categroyId = value;
                OnPropertyChanged();
            }
        }
        public string? Image
        {
            get => image; set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        public int Tax
        {
            get => tax; set
            {
                tax = value;
                OnPropertyChanged();
            }
        }
    }
}
