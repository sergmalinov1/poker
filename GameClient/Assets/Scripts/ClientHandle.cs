using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived(); 
    }

    public static void AuthAnswer(Packet _packet)
    {
        string code = _packet.ReadString();
        int num = _packet.ReadInt();

        Client.instance.Authorization(code);
    }


    public static void NewSpectator(Packet _packet)
    {
        int _myId = _packet.ReadInt();
        string _username = _packet.ReadString();

        Debug.Log($"NewSpectator: {_myId} + __ + {_username}");


    }

}
