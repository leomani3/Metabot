using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{

    public string content;
    public GameObject sender;
    public GameObject receiver;
    public float heading;

    public Message(GameObject sender, string content, GameObject receiver)
    {
        this.content = content;
        this.sender = sender;
        this.receiver = receiver;
        heading = Utility.getAngle(receiver, sender);
    }

    public Message(GameObject sender, string content)
    {
        this.sender = sender;
    }

    public Message(Message M)
    {
        content = M.content;
        sender = M.sender;
        receiver = M.receiver;
        heading = M.heading;
    }
}
