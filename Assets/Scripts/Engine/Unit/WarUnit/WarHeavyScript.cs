using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHeavyScript : MovableUnitScript
{
    void Start()
    {
        unit = new WarHeavy(gameObject.GetComponentInParent<TeamScript>().Team, gameObject);
    }
}
