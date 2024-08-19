using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace Chat_Win_App.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _status;
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class UserListViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private UserViewModel _selectedUser;
        private readonly ObservableCollection<UserViewModel> _users;
        public UserListViewModel()
        {
            _users = new ObservableCollection<UserViewModel>();
            SearchCommand = new RelayCommand(SearchUsers);
            LoadUsers();
        }
        public ObservableCollection<UserViewModel> Users => _users;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    SearchUsers();
                }
            }
        }
        public UserViewModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand SearchCommand { get; }
        private void LoadUsers()
        {
            
        }
        private void SearchUsers()
        {
            if (string.IsNullOrWhiteSpace(_searchText))
            {
                foreach (var user in _users)
                {
                    user.Status = "Visible";
                }
            }
            else
            {
                foreach (var user in _users)
                {
                    if (user.UserName.Contains(_searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        user.Status = "Visible";
                    }
                    else
                    {
                        user.Status = "Hidden";
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}