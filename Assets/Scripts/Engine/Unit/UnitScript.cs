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
        //TODO : Gérer la mise à jour des percepts
                //Gérer les messages
        unit.Brain.decide(unit);
        unit.RunAction();
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
