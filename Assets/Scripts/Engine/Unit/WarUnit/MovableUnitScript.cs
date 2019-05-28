using UnityEngine;

public class MovableUnitScript : UnitScript
{

    void OnCollisionEnter(Collision other)
    {
        ((MovableUnit)unit).OnCollisionEnter(other);
    }

    void OnCollisionStay(Collision other)
    {
        ((MovableUnit)unit).OnCollisionStay(other);
    }
}

