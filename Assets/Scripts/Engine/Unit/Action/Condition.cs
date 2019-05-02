using System;
//using System.Data;
using System.Collections;
using System.Collections.Generic;

public class Condition
{
	private string stringExpression;
	
	public Condition(string text){
		stringExpression = text;
	}
	
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
	}
}