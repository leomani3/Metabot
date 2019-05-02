using System;
//using System.Data;
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
	
<<<<<<< HEAD
	public bool satisfied(Unit unit){	
		
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
=======
	public bool satisfied(Unit unit){
        /*//remplacer les variables ecrites en string par leur valeur
		stringExpression.Replace("currenHealth", unit.CurrentHealth);
		//--
		
		return evaluate(stringExpression);*/
        return true;
	}
	
	public bool evaluate(string logicalExpression){
        /*System.Data.DataTable table = new System.Data.DataTable();
		table.Columns.Add("", typeof(bool));
		table.Columns[0].Expression = logicalExpression;

		System.Data.DataRow r = table.NewRow();
		table.Rows.Add(r);
		bool result = (Boolean)r[0];
		return result;*/
        return true;
>>>>>>> 2dfc69d3fd25afbea915b43422c2cd9a4fba0fed
	}
}