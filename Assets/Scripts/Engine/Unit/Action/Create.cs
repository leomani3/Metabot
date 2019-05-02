using System;
using System.Collections;
using System.Collections.Generic;

public class Create : Action
{	
	public Create(string param, string meth): base(param, meth){}
	
	public void setup(Unit unit){
		unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
		unit.creator.type = parametre;
	}
}