using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Projectile
{
    public HeavyBullet(GameObject go, float speed = 10.0f, float damage = 50.0f, float explosionRadius = 1.0f, float autonomy = 5.0f) : base(go, speed, damage, explosionRadius, autonomy) { }
}
