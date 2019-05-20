using System;
using System.Collections;
using System.Collections.Generic;

public class MetaInstruction
{
	private List<Condition> conditions;
	private MetaAction action;
	
	public MetaInstruction(string param, string meth){
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
	
	public bool satisfied(Unit unit){
        bool satisfied = true;
        int i = 0;
        while(satisfied && i < conditions.Count)
        {
            satisfied = conditions[i].satisfied(unit);
            i++;
        }
        return satisfied;
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