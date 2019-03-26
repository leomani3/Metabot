using System;
using UnityEngine;

public class Projectile
{
    public static Projectile LIGHT_BULLET = new Projectile(10.0f, 20.0f, 0.5f, 3.0f);

    readonly float speed;
    readonly float damage;
    readonly float explosionRadius;
    readonly float autonomy;
    GameObject projectile_go;
    Vector3 direction;
    
    public Projectile(float speed, float damage, float explosionRadius, float autonomy)
    {
        this.speed = speed;
        this.damage = damage;
        this.explosionRadius = explosionRadius;
        this.autonomy = autonomy;
    }

    public GameObject Projectile_go
    {
        get { return projectile_go; }
    }

    public Vector3 Direction
    {
        get { return Direction; }
        set { this.direction = value; }
    }

    public void Move()
    {
        this.projectile_go.transform.position += speed * direction.normalized * 0.2f;
    }
}
