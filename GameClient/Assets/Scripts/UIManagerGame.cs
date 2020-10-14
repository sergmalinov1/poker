using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIManagerGame : MonoBehaviour
{
    public static UIManagerGame instance;

    
    public InputField chatInput;

    public Transform chatContent;
    public GameObject chatMessage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }


    public void SentMsgToChat()
    {
        string msg = chatInput.text;

        if (msg != "")
        {
            GameObject newMsg = Instantiate(chatMessage, chatContent);
            Text content = newMsg.GetComponent<Text>();
            content.text = string.Format(content.text, "ME: ", msg);

            ClientSend.SendChatMsg();

            chatInput.text = "";
        }
     
    }

    public void ShowMsgToChat(string user, string msg)
    {
        Debug.Log($"ShowMsgToChat");
        if (msg != "")
        {
          
            GameObject newMsg = Instantiate(chatMessage, chatContent);
            Text content = newMsg.GetComponent<Text>();
            content.text = string.Format(content.text, user, msg);
      
        }
    }


    public void Disconect()
    {
        Client.instance.Disconnect();
    }
}
