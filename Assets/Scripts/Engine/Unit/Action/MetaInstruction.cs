using System;
using System.Collections;
using System.Collections.Generic;

public class MetaInstruction
{
	private ArrayList conditions;
	private MetaAction action;
	
	public MetaInstruction(string param, string meth){
		//conditions.Add(new Condition(cond));
		if(meth == "create"){
			action = new Create(meth, param);
		}else{
			action = new MetaAction(meth, param);			
		}
	}
	
	public bool satisfied(Unit unit){
        bool satisfied = true;
        int i = 0;
        while(satisfied && i < conditions.Count)
        {

        }
        return satisfied;
	}

    public MetaAction Action
    {
        get
        {
            return action;
        }
    }
}