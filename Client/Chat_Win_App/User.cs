namespace Chat_Win_App
{
    public class User
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public User(string username, string status = "Online")
        {
            Username = username;
            Status = status;
        }
        public User()
        {
            Username = "Unknown";
            Status = "Offline";
        }
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
        public override string ToString()
        {
            return $"{Username} ({Status})";
        }
    }
}