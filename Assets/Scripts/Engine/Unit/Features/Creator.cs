using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : Feature
{
    List<System.Type> creatableUnits = new List<System.Type>();
    System.Type type;

    public Creator(Unit unit, List<System.Type> canCreateUnits) : base(unit)
    {
        creatableUnits = canCreateUnits;
    }

    public void Create()
    {
        if (creatableUnits.Contains(type))
        {
            GameObject go = Resources.Load<GameObject>("Prefab/Unit/" + type.Name);
            Debug.Log(go);
            Object.Instantiate(go, unit.Unit_go.transform.position, Quaternion.identity);
        }
    }   

    public System.Type Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
}
