using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBulletScript : ProjectileScript
{
    void Start()
    {
        projectile = new HeavyBullet(gameObject);
        projectile.Direction = Utility.vectorFromAngle(projectile.Projectile_go.transform.eulerAngles.y);
    }

}
