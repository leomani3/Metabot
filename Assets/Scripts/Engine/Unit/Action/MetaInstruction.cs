using System;
using System.Collections;
using System.Collections.Generic;

public class MetaInstruction
{
	private Condition condition;
	private MetaAction action;
	
	public MetaInstruction(Brain b, string cond, string param, string meth){
		condition = new Condition(cond);
		if(meth == "create"){
			action = new Create(meth, param);
		}else{
			action = new MetaAction(meth, param);			
		}
	}
	
	public bool satisfied(Unit unit){	
		return condition.satisfied(unit);
	}

    public MetaAction Action
    {
        get
        {
            return action;
        }
    }
}