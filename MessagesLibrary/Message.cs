using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public abstract class Message
    {
        public Message(string userName)
        {
            this.UserName = userName;
        }
        public string UserName { get; set; }
    }
}
