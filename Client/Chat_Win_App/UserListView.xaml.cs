using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Chat_Win_App
{
    public partial class UserListView : Window
    {
        private List<User> _users;
        public UserListView(List<User> users)
        {
            InitializeComponent();
            _users = users;
            LoadUserList();
        }
        private void LoadUserList()
        {
            UserListBox.Items.Clear();
            foreach (var user in _users)
            {
                UserListBox.Items.Add(user);
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = (sender as TextBox).Text.ToLower();
            UserListBox.Items.Clear();

            foreach (var user in _users)
            {
                if (user.Username.ToLower().Contains(searchText))
                {
                    UserListBox.Items.Add(user);
                }
            }
        }
        private void UserListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserListBox.SelectedItem is User selectedUser)
            {
                MessageBox.Show($"Selected user: {selectedUser.Username}");
            }
        }
    }
}