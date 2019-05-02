using System;
using System.Collections;
using System.Collections.Generic;

public class Action
{	
	protected string parametre;
	protected string methode;

	public Action(string param, string meth){
		parametre = param;
		methode = meth;
	}
	
	public void setup(Unit unit){
		unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
	}
}