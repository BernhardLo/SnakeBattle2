using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class PlayMessage : Message
    {
        public PlayMessage(string userName) : base(userName)
        {

        }

        public string HostName { get; set; }
        public List<int[]> MoveList { get; set; }
        public bool IsAlive { get; set; }
        public Player NextUser { get; set; }
        public Player ThisPlayer { get; set; }
        public bool StartTurn { get; set; }

    }
}
