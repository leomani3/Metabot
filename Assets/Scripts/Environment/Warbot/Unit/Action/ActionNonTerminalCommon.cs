using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//On le met dans environnement MAIS ACTION_MESSAGE_POSITION devrait en réalité faire partie du noyau
public class ActionNonTerminalCommon : ActionNonTerminal
{
    

    void Start()
    {
        InitActionNonTerminal();
    }

    public override void InitActionNonTerminal()
    {
        _actionsNT["ACTN_MESSAGE_HELP"] = delegate ()
        {
            Message message = new Message(gameObject, "MESSAGE_HELP");
            GetComponent<MessageManager>().Send(message, _messageDestinataire);

        };
        _actionsNT["ACTN_MESSAGE_POSITION"] = delegate ()
        {
            Message message = new Message(gameObject, "MESSAGE_POSITION");
            GetComponent<MessageManager>().Send(message, _messageDestinataire);
        };
        _actionsNT["ACTN_MESSAGE_ATTACK"] = delegate ()
        {
            Message message = new Message(gameObject, "MESSAGE_ATTACK", GetComponent<Stats>().GetTarget());
            GetComponent<MessageManager>().Send(message, _messageDestinataire);
          
        };
        _actionsNT["ACTN_MESSAGE_POSITION_RESOURCE"] = delegate ()
        {
            Message message = new Message(gameObject, "MESSAGE_POSITION_RESOURCE");
            GetComponent<MessageManager>().Send(message, _messageDestinataire);
        };
    }
}
