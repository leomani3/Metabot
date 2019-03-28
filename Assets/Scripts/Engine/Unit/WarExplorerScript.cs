using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarExplorerScript : UnitController {

    // Use this for initialization
    void Start()
    {
        unit = new WarExplorer()
        {
            Unit_go = gameObject
        };
        //unit.Unit_go.transform.Rotate(Quaternion.Euler(0, unit.Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in unit.Unit_go.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (unit.CurrentHealth <= 0)
            Destroy(unit.Unit_go);
    }

    void OnCollisionStay(Collision other)
    {
        //unit.OnCollisionStay(other);
    }
}
