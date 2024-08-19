using System.Collections.ObjectModel;
namespace Chat_Win_App.Controllers
{
    public class UserController
    {
        public ObservableCollection<User> Users { get; private set; }
        public User CurrentUser { get; internal set; }
        public UserController()
        {
            Users = new ObservableCollection<User>();
        }
        public void AddUser(string userName, string status)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("User name cannot be empty.", nameof(userName));
            var user = new User
            {
                Username = userName,
                Status = status
            };
            Users.Add(user);
        }
        public void RemoveUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            Users.Remove(user);
        }
        public User FindUser(string userName)
        {
            return Users.FirstOrDefault(u => u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }
        public void UpdateUserStatus(User user, string newStatus)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.Status = newStatus;
        }
    }
}