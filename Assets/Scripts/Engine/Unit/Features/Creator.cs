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
        //L'UNITE DOIT PERDRE DE LA VIE, TEST 
        if (creatableUnits.Contains(type))
        {
            GameObject go = Resources.Load<GameObject>("Prefab/Unit/" + type.Name);
            Object.Instantiate(go, unit.Unit_go.transform.position + new Vector3(1,0,2), Quaternion.identity, unit.Unit_go.transform.parent);
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
