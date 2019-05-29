using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MetaComportement{

	public MetaAction action;
	public abstract bool satisfied(Unit unit);

	override
	public string ToString(){
		string s = "";
		s += action.ToString();
		return s;
	}
}