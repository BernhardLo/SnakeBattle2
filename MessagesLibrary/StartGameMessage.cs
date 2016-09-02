using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class StartGameMessage : Message
    {
        public string HostName { get; set; }
        public List<Player> PlayerList { get; set; }
        public int fieldSize { get; set; }
        public StartGameMessage(string userName) : base(userName)
        {
            PlayerList = new List<Player>();
        }
    }
}
