using System;
using System.Collections.Generic;
using UnityEngine;

public class MetaInstruction : MetaComportement
{
	private List<Condition> conditions;
	
	public MetaInstruction(string meth, string param)
    {
        conditions = new List<Condition>();
        switch (meth) {
            case "Create":
                action = new Create(meth, param);
                break;
            case "Move":
                action = new Move(meth, param);
                break;
            default:
                action = new MetaAction(meth, param);
                break;
        }
	}
	
	override
	public bool satisfied(Unit unit){
		for (int i = 0; i < conditions.Count; i++) {
			if (!conditions[i].satisfied(unit))
				return false;
		}
		return true;
	}

    public void addCondition(Condition cond)
    {
        conditions.Add(cond);
    }

    public MetaAction Action
    {
        get
        {
            return action;
        }
    }

    override
    public string ToString()
    {
        string s = "";
        foreach(Condition c in conditions)
        {
            s += c.ToString() + "\n";
        }
        s += action.ToString();
        return s;
    }
}