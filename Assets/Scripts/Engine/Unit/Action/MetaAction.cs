using System;
using UnityEngine;

public class MetaAction
{	
	protected string parametre;
	protected string methode;

	public MetaAction(string meth, string param)
    {
		parametre = param;
		methode = meth;
	}
	
	public void setup(Unit unit){
		unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
        switch (methode)
        {
            case "Create":
                ((WarBase)unit).CreatorFeature.Type = Type.GetType(parametre);
                break;
            default :
                break;
        }
	}
    
    override
    public string ToString()
    {
        return "methode : " + methode + " param : " + parametre;
    }
}