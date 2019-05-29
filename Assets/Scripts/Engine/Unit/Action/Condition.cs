using UnityEngine;
public class Condition
{
	private string stringExpression;
    private string param1, param2;
    private string operateur;
	
	public Condition(string text){
		stringExpression = text;
        string[] tmp = stringExpression.Split(' ');
        param1 = tmp[0];
        operateur = tmp[1];
        for(int i = 2; i < tmp.Length; i++)
        {
            param2 += tmp[i] + " ";
        }
    }
    
    public bool satisfied(Unit unit) {
        //Debug.Log(param1 + " = " + unit.LookUp(param1.Trim()) + " " + operateur + " " + param2 + " = " + unit.LookUp(param2.Trim()));
        //Debug.Log("nearBaseAllie = " + unit.LookUp("nearBaseAllie"));
        switch (operateur)
        {
            case ">":
                return unit.LookUp(param1.Trim()) > unit.LookUp(param2.Trim());
            case ">=":
                return unit.LookUp(param1.Trim()) >= unit.LookUp(param2.Trim());
            case "==":
                return unit.LookUp(param1.Trim()) == unit.LookUp(param2.Trim());
            case "<":
                return unit.LookUp(param1.Trim()) < unit.LookUp(param2.Trim());
            case "<=":
                return unit.LookUp(param1.Trim()) <= unit.LookUp(param2.Trim());
        }
        return false;
    }

    override
    public string ToString()
    {
        return stringExpression;
    }
}