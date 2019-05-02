using System;
using System.Collections;
using System.Collections.Generic;

public class Action
{	
	private string parametre;
	private string methode;

	public Action(string param, string meth){
		parametre = param;
		methode = meth;
	}
	
	public void setup(Unit unit){
		unit.nextAction = Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
	}
}