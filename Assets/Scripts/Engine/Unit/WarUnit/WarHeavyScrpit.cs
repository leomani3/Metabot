using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHeavyScrpit : UnitScript
{
    // Start is called before the first frame update
    void Start()
    {
        unit = new WarHeavy(gameObject.GetComponentInParent<WorldTest>().TeamRed, 0.0f)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, unit.Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
