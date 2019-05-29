using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNTG : ActionG
{
    public override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.AddActionNTG(this);
    }

    public override void DeleteFromList()
    {
        if (this.blockinstruction != null) this.blockinstruction.RemoveActionNTG(this);
    }
}
