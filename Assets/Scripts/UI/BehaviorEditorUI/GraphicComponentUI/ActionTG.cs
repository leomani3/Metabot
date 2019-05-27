using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTG : ActionG
{
    protected override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.SetActionTG(this);
    }
}
