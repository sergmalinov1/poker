using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class Room
    {
        public int MaxPlayersInRoom { get; private set; }
        public List<Client> playersInRoom = new List<Client>();
        public List<Client> spectators = new List<Client>();

        public Room()
        {
            MaxPlayersInRoom = 6;
        }

        public void JoinTheRoom(int _clientId)
        {
            if (playersInRoom.Count >= MaxPlayersInRoom)
            {
                //send net_mest
                return;
            }
            else
            {
                
                //sent _clientId ti v igre
            }



            Client client = Server.clients[_clientId];
            Player player = client.player;

            Console.WriteLine($"JoinTheRoom " + player.username);

            playersInRoom.Add(client);

            if (spectators.Contains(client))
                spectators.Remove(client);          

            ServerSend.NewPlayer(player);
        }


        public void LeaveTheRoom(Client _cl)
        {
            if (Server.room.spectators.Contains(_cl))
            {
                Server.room.spectators.Remove(_cl);
                Console.WriteLine($"spectators leaveTheRoom  " + _cl.player.username);
            }


            if (Server.room.playersInRoom.Contains(_cl))
            {
                Server.room.playersInRoom.Remove(_cl);
                Console.WriteLine($"player leaveTheRoom  " + _cl.player.username);
            }
        }
        
    }
}
