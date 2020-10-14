﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            _packet.Write(Client.instance.login);
            _packet.Write(Client.instance.pass);

            SendTCPData(_packet);
        }
    }

    public static void SendChatMsg()
    {
        using (Packet _packet = new Packet((int)ClientPackets.chatMsgReceived))
        {
            _packet.Write(Client.instance.login);
            _packet.Write(UIManagerGame.instance.chatInput.text);

            SendTCPData(_packet);
        }
    }

    #endregion
}
