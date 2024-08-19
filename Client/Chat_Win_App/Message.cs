using System;
namespace Chat_Win_App
{
    public class Message
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsFile { get; set; }
        public string FileName { get; set; }
        public Message(string sender, string text, DateTime timestamp, bool isFile = false, string fileName = null)
        {
            Sender = sender;
            Text = text;
            Timestamp = timestamp;
            IsFile = isFile;
            FileName = fileName;
        }
        public override string ToString()
        {
            if (IsFile)
            {
                return $"{Timestamp:G} - {Sender} sent a file: {FileName}";
            }
            return $"{Timestamp:G} - {Sender}: {Text}";
        }
    }
}