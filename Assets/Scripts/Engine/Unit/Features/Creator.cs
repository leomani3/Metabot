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
            GameObject created = Object.Instantiate(go, new Vector3(unit.Unit_go.transform.position.x + 1,0, unit.Unit_go.transform.position.z + 5), Quaternion.identity, unit.Unit_go.GetComponentInParent<TeamScript>().gameObject.transform);
            unit.CurrentHealth -= 150; //Pour la perte de vie il faudrait regarder le cout d'une unité
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
