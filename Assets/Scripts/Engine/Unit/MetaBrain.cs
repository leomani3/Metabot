using System;
using System.Collections;
using UnityEngine;

public class MetaBrain
{
	private ArrayList instructions;
	
	private delegate void ActionToReturn();

    public MetaBrain(ArrayList instr)
    {
		instructions = instr;
    }
	
	public void decide(Unit unit){
		//ORDONNER LES INSTRUCTIONS PAR PRIORITES
        //if(unit.CollisionObject == null)
            foreach (MetaInstruction i in instructions)
                if (i.satisfied(unit))
                    i.Action.setup(unit);
        //else
        //    //unit.Heading = unit.CollisionObject.
        //    unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, "Move");
	}

    override
    public string ToString()
    {
        string s = "";
        foreach(MetaInstruction instr in instructions) {
            s += instr.ToString() + "\n";
        }
        return s;
    }
}