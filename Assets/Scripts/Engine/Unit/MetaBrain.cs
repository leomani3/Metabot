using System;
using System.Collections.Generic;
using UnityEngine;

public class MetaBrain
{
	private List<MetaComportement> comportements;
	
	private delegate void ActionToReturn();

    public MetaBrain(List<MetaComportement> comps){
		comportements = comps;
    }
	
	public void decide(Unit unit){
        //ORDONNER LES INSTRUCTIONS PAR PRIORITES
        foreach (MetaComportement c in comportements)
        {
            //Debug.Log(unit.GetType().ToString() + " : cond = " + i.ToString() + " = " + i.satisfied(unit));
            if (c.satisfied(unit)) {
                c.action.setup(unit);
                break;
            }
        }
		
	}

    override
    public string ToString()
    {
        string s = "";
        foreach(MetaComportement comp in comportements) {
            s += comp.ToString() + "\n";
        }
        return s;
    }
}