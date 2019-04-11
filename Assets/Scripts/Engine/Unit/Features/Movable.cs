using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : Feature
{
    protected readonly float speed;

    public Movable(Unit unit, float speed) : base(unit)
    {
        this.speed = speed;
    }

    public void Move()
    {
        if (!unit.IsBlocked())
        {
            unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.2f;
        }
        else
            unit.Unit_go.transform.position *= 1;//Faire quelque chose
    }

}
