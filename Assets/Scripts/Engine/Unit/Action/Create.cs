using System;
using System.Collections;
using System.Collections.Generic;

public class Create : Action
{	
	public Create(string param, string meth): (param, meth){}
	
	public void setup(Unit unit){
		unit.nextAction = Delegate.CreateDelegate(typeof(Unit.Action), unit, i.methode);
		unit.creator.nextToCreate = param;
	}
}