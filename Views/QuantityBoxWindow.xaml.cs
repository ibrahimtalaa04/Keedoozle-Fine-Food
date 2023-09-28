namespace Keedoozle_Fine_Food.Views
{

    public partial class QuantityBoxWindow : Window
    {
        public QuantityBoxWindow(QuantitBoxViewModel quantitBoxViewModel)
        {
            InitializeComponent();
            DataContext = quantitBoxViewModel;
        }
    }
}
