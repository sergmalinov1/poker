using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class Room
    {
        public int MaxPlayersInRoom { get; private set; }
        public Dictionary<int, Client> playersInRoom = new Dictionary<int, Client>();
        public List<Client> spectators = new List<Client>();

        public Room()
        {

        }

    }
}
