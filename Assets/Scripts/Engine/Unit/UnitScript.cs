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

    void Update()
    {
        Debug.Log("VIE ACTUELLE :" + unit.CurrentHealth);
        unit.Brain.decide(unit);
        unit.RunAction();
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
