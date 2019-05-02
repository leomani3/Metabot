using System;
using System.Collections;
using System.Collections.Generic;

public class Instruction
{
	private Condition condition;
	private Action action;
	
	//action c'est quoi comme type?
	public Instruction(Brain b, string cond, string param, string meth){
		condition = new Condition(cond);
		if(meth == "create"){
			action = new Create(b, meth, param);
		}else{
			action = new Action(b, meth, param);			
		}
	}
	
	public boolean satisfied(Unit unit){	
		condition.satisfied(unit);
	}
}