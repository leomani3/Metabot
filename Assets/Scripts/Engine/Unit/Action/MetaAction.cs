using System;
using System.Collections;
using System.Collections.Generic;

public class MetaAction
{	
	protected string parametre;
	protected string methode;

	public MetaAction(string param, string meth){
		parametre = param;
		methode = meth;
	}
	
	public void setup(Unit unit){
		unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
	}

    override
    public string ToString()
    {
        return "methode : " + methode + " param : " + parametre;
    }
}