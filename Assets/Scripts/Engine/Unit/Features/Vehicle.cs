using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : Feature
{
    protected readonly float speed;

    public Vehicle(float speed, Unit unit) : base(unit)
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
