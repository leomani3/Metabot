using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHeavyScript : UnitScript
{
    // Start is called before the first frame update
    void Start()
    {
        unit = new WarHeavy(gameObject.GetComponentInParent<UnitScript>().Unit.Team, 0.0f)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarHeavy)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
