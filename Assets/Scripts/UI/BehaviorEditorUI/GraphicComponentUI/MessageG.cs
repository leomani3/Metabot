using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageG : ActionG
{
    protected override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.AddMessagesG(this);
    }
}
