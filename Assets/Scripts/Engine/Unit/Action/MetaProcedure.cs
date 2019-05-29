using System;
using System.Collections.Generic;
using UnityEngine;

public class MetaProcedure : MetaComportement{

	private string name;
	private List<MetaComportement> comportements;
	
	public MetaProcedure(string name, List<MetaComportement> lcomp){
		this.name = name;
		this.comportements = lcomp;
	}

	override
	public bool satisfied(Unit unit){
		foreach (MetaComportement c in comportements) {
			if (c.satisfied(unit)) {
				this.action = c.action;
				return true;
			}
		}
		return false;
	}

	override
	public string ToString(){
		string s = "";
		foreach (MetaComportement c in comportements) {
			s += c.ToString() + "\n";
		}
		s += action.ToString();
		return s;
	}
}