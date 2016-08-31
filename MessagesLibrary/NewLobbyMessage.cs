using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class NewLobbyMessage : Message
    {
        public NewLobbyMessage(string userName, bool create) : base (userName)
        {
            Create = create;
        }

        public bool Create { get; set; }
    }
}
