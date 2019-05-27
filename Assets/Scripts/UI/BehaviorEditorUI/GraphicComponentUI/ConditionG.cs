using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionG : GraphicComponent
{
    private int priorityOrder;

    protected override void AddToBlockInstruction()
    {
        BlockInstruction[] blockInstructions = FindObjectsOfType(typeof(BlockInstruction)) as BlockInstruction[];

        foreach (BlockInstruction b in blockInstructions)
        {
            Transform posB = b.GetTransform();
            Vector3 posRelative = posB.InverseTransformPoint(transform.position);
            int bID = (int)posRelative.y - (int)(this.size.y / 2);

            if (bID == 0)
            {
                this.blockinstruction = b;
                b.AddConditionG(this);
                break;
            }
        }
    }
}
