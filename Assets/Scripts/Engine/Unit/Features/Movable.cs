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
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(((MovableUnit)unit).Heading).normalized * 0.2f;
    }

}
