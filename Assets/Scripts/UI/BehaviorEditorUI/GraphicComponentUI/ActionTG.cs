using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTG : ActionG
{
    public override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.SetActionTG(this);
    }

    public override void DeleteFromList()
    {
        if (this.blockinstruction != null) this.blockinstruction.RemoveActionTG(this);
    }
}
