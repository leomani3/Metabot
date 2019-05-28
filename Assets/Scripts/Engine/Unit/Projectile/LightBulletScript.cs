using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulletScript : ProjectileScript
{
    void Start()
    {
        projectile = new LightBullet(gameObject);
        projectile.Direction = Utility.vectorFromAngle(projectile.Projectile_go.transform.eulerAngles.y);
    }

}
