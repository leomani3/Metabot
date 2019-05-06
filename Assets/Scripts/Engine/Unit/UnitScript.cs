using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    protected Unit unit;

    public Unit Unit
    {
        get { return unit; }
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }

    void Update()
    {
        unit.Brain.decide(unit);
        unit.RunAction();
    }
}
