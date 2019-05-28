using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHeavyScript : UnitScript
{
    // Start is called before the first frame update
    void Start()
    {
        unit = new WarHeavy(gameObject.GetComponentInParent<TeamScript>().Team, gameObject);
    }
}
