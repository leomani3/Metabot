using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageG : ActionG
{
    public override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.AddMessagesG(this);
    }

    public override void DeleteFromList()
    {
        if (this.blockinstruction != null) this.blockinstruction.RemoveMessagesG(this);
    }
}
