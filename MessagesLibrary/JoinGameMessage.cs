using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class JoinGameMessage : Message
    {
        public string HostName { get; set; }
        public bool Confirmed { get; set; }

        public List<Player> PlayerListLobby;

        public JoinGameMessage(string userName) : base(userName)
        {
            PlayerListLobby = new List<Player>() { new Player("<empty>") };
        }
    }
}
