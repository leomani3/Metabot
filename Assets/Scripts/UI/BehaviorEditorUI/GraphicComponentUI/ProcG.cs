using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcG : BlockInstruction
{
    public void TakeAttributes(BlockInstruction blockIf)
    {
        this.SetAllConditionGs(blockIf.GetConditionGs());
        this.SetAllMessagesGs(blockIf.GetMessageGs());
        this.SetAllActionNTGs(blockIf.GetActionNTGs());
        this.SetAllActionTG(blockIf.GetActionTG());
    }
}
