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
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.2f;
        float angle = Quaternion.Angle(unit.Unit_go.transform.rotation, Quaternion.AngleAxis(unit.Heading, Vector3.up));
        unit.Unit_go.transform.Rotate(Quaternion.AngleAxis(angle,Vector3.up).eulerAngles);
    }

}
