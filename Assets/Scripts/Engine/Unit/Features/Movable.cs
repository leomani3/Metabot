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
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            //Debug.Log(other.gameObject.name);
            //other.collider.transform
            /*foreach (ContactPoint contact in other.contacts)
            {
                float a = Utility.getAngle(unit_go.transform.position, contact.point);
                float A = Mathf.Abs(a - heading);
                float B = Mathf.Abs(360 + Mathf.Min(a, heading) - Mathf.Max(a, heading));
                if (Mathf.Min(A, B) < 90f)
                {
                    collisionObject = other.transform.gameObject;
                    heading = (Mathf.Min(A, B) + 180.0f) % 360.0f;
                    break;
                }
            }*/
        }
    }

}
