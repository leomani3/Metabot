﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNonTerminalCommon : ActionNonTerminal
{

    void Start()
    {
        InitActionNonTerminal();
    }

    public override void InitActionNonTerminal()
    {
        _actionsNT["MESSAGE_HELP"] = delegate (string dest)
        {
            Message message = new Message(gameObject, "MESSAGE_HELP");
            GetComponent<MessageManager>().Send(message, dest);
        };


    }
}
