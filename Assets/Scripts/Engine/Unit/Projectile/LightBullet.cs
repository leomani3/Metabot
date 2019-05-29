using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : Projectile
{
    public LightBullet(GameObject go, float speed = 10.0f, float damage = 20.0f, float explosionRadius = 0.5f, float autonomy = 3.0f) : base(go ,speed, damage, explosionRadius, autonomy) { }
}
