using System;
using System.Collections;
using System.Collections.Generic;

public class Condition
{
	private string stringExpression;
    private string param1, param2;
    private string operateur;
	
	public Condition(string text){
		stringExpression = text;
	}
    
    public bool satisfied(Unit unit) {

        switch (operateur)
        {
            case ">":
                return unit.LookUp(param1) > unit.LookUp(param2);
            case ">=":
                return unit.LookUp(param1) >= unit.LookUp(param2);
            case "==":
                return unit.LookUp(param1) == unit.LookUp(param2);
            case "<":
                return unit.LookUp(param1) < unit.LookUp(param2);
            case "<=":
                return unit.LookUp(param1) <= unit.LookUp(param2);
        }
        return false;
    }
}