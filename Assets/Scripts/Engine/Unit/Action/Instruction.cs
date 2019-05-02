using System;
using System.Collections;
using System.Collections.Generic;

public class Instruction
{
	private Condition condition;
	private Action action;
	
	//action c'est quoi comme type?
	public Instruction(string cond, string param, string meth){
		condition = new Condition(cond);
		if(meth == "create"){
			action = new Create(meth, param);
		}else{
			action = new Action(meth, param);			
		}
	}
	
	public bool satisfied(Unit unit){	
		return condition.satisfied(unit);
	}
}