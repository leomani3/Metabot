using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarExplorerScript : UnitScript
{
    // Use this for initialization
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<WorldTest>().TeamRed)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, unit.Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Unit.GetAllPerceptsInRadius();
        if (unit.PerpeptsInSight.Count > 0)
            ;
        else
            ;
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
