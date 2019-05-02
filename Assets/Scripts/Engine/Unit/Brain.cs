using System;
using System.Collections;
using System.Collections.Generic;

public class Brain
{
	private ArrayList instructions;
	
	private delegate void ActionToReturn();

    public Brain(ArrayList instr)
    {
		instructions = instr;
    }
	
	public void decide(Unit unit){
		//ORDONNER LES INSTRUCTIONS PAR PRIORITES
		for(Instruction i in instructions){
			if(i.satisfied(unit)){
				i.action.setup(unit);
			}
		}
	}
}