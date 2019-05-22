﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Creator : Feature
{
    List<Type> creatableUnits = new List<Type>();
    public Type Type { get; set; }

    public Creator(Unit unit, List<Type> canCreateUnits) : base(unit)
    {
        creatableUnits = canCreateUnits;
    }

    public void Create()
    {
        if (creatableUnits.Contains(Type))
        {
            GameObject go = Resources.Load<GameObject>("Prefab/Unit/" + Type.Name);
            GameObject created = UnityEngine.Object.Instantiate(go, new Vector3(unit.Unit_go.transform.position.x + 1,0, unit.Unit_go.transform.position.z + 5), Quaternion.identity, unit.Unit_go.GetComponentInParent<TeamScript>().gameObject.transform);
            Debug.Log("Avant : " + unit.LookUp("currentHealth"));
            unit.CurrentHealth -= 150; //Pour la perte de vie il faudrait regarder le cout d'une unité
            Debug.Log("Apres : " + unit.LookUp("currentHealth"));
        }
    }

}
