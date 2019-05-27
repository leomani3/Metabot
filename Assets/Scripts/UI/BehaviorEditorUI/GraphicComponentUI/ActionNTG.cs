using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNTG : ActionG
{
    protected override void AddToBlockInstruction()
    {
        base.AddToBlockInstruction();
        this.blockinstruction.AddActionNTG(this);
    }
}
