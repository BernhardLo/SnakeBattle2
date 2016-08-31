using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class NewLobbyMessage : Message
    {
        public NewLobbyMessage(string userName) : base (userName)
        {

        }

        public bool Create { get; set; }
    }
}
