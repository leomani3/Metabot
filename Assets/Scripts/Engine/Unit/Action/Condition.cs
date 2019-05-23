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

    override
    public string ToString()
    {
        return stringExpression;
    }
}