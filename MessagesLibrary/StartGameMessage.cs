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
        public StartGameMessage(string userName) : base(userName)
        {

        }
        public GameRoom GameRoomInfo { get; set; }
    }
}
