using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MessageManager : MonoBehaviour {

    public GameObject sender;
    public List<Message> waitingMessages = new List<Message>();
    public List<Message> currentMessages = new List<Message>();
    public string[] messageType;
    public GameObject messageLineObject;

    private Dictionary<GameObject,GameObject> messageLineObjects = new Dictionary<GameObject, GameObject>();

    public abstract void Init();

    public void UpdateMessage()
    {
        currentMessages = waitingMessages;

        waitingMessages = new List<Message>();
    }
    

    public void Send(Message message, string dest)
    {
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            if (!unit.Equals(this.gameObject) &&unit.GetComponent<Stats>()._teamIndex == GetComponent<Stats>()._teamIndex && 
                ((unit.GetComponent<Stats>()._unitType == dest) || (dest == "All")))
            {


                Message M = new Message(message);
                CreateMessageLineObject(unit);
                M.receiver = unit;
                M.heading = Utility.getAngle(unit, gameObject);
                unit.GetComponent<MessageManager>().waitingMessages.Add(M);
            }
        }
    }


    public void CreateMessageLineObject(GameObject unit)
    {
        if ((!messageLineObjects.ContainsKey(unit)) || (messageLineObjects.ContainsKey(unit) &&messageLineObjects[unit] == null))
        { 
            GameObject messageLine = Instantiate(messageLineObject);
            messageLine.GetComponent<MessageLineScript>()._sender = this.gameObject;
            messageLine.GetComponent<MessageLineScript>()._receiver = unit;
            messageLineObjects[unit] = messageLine;
        }
    }

    public void Send(Message message, GameObject dest)
    {
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            if (unit.GetComponent<Stats>()._teamIndex == GetComponent<Stats>()._teamIndex && unit == dest)
            {
                unit.GetComponent<MessageManager>().waitingMessages.Add(message);
            }
        }
    }

    public Message ContainsType(string type)
    {
        foreach (Message m in currentMessages)
        {
            if (m.content == type) return m;
        }
        return null;
    }






}
