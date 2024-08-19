using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Chat_Win_App.Models;
using Chat_Win_App.ViewModels;
namespace Chat_Win_App
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        private readonly UserListViewModel _userListViewModel;
        private readonly ChatViewModel _chatViewModel;
        public MainViewModel()
        {
            _userListViewModel = new UserListViewModel();
            _chatViewModel = new ChatViewModel();
            CurrentView = _userListViewModel;
            ShowUserListCommand = new RelayCommand(ShowUserList);
            ShowChatCommand = new RelayCommand(ShowChat);
            _userListViewModel.PropertyChanged += OnUserListViewModelPropertyChanged;
        }
        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ShowUserListCommand { get; }
        public ICommand ShowChatCommand { get; }
        private void ShowUserList()
        {
            CurrentView = _userListViewModel;
        }
        private void ShowChat()
        {
            CurrentView = _chatViewModel;
        }
        private void OnUserListViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserListViewModel.SelectedUser) && _userListViewModel.SelectedUser != null)
            {
                _chatViewModel.SelectedUser = _userListViewModel.SelectedUser;
                ShowChat();
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