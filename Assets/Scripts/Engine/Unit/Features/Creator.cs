using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : Feature
{
    List<System.Type> creatableUnits = new List<System.Type>();

    public Creator(Unit unit, List<System.Type> canCreateUnits) : base(unit)
    {
        creatableUnits = canCreateUnits;
    }

    public void Create(System.Type type)
    {
        if (creatableUnits.Contains(type))
        {
            GameObject go = Resources.Load<GameObject>("Prefab/Unit/" + type.Name);
            Object.Instantiate(go, unit.Unit_go.transform.position, Quaternion.identity);
        }
    }   
}
