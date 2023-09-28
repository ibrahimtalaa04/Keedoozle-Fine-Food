namespace Keedoozle_Fine_Food.ViewModels
{
    public class ItemCategoryViewModel : ViewModelBase
    {

        private int _id;
        private string? _categoryName;

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public int Id1
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();

            }
        }
        public string? CategoryName1
        {
            get => _categoryName; set
            {
                _categoryName = value;
                OnPropertyChanged();

            }
        }
    }
}
