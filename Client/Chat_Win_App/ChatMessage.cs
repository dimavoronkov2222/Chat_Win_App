using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Win_App
{
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
