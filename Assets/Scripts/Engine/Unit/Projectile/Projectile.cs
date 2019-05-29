using UnityEngine;

public abstract class Projectile
{
    readonly float speed;
    readonly float damage;
    readonly float explosionRadius;
    float autonomy;
    GameObject projectile_go;
    Vector3 direction;

    protected Projectile(GameObject go, float speed, float damage, float explosionRadius, float autonomy)
    {
        this.speed = speed;
        this.damage = damage;
        this.explosionRadius = explosionRadius;
        this.autonomy = autonomy;
        this.projectile_go = go;
    }

    public GameObject Projectile_go
    {
        get { return projectile_go; }
        set { this.projectile_go = value; }
    }

    public Vector3 Direction
    {
        get { return Direction; }
        set { this.direction = value; }
    }

    public void Move()
    {
        autonomy -= Time.fixedDeltaTime;
        if (autonomy <= 0)
        {
            Object.Destroy(projectile_go);
        }
        else
            this.projectile_go.transform.position += speed * direction.normalized * 0.2f;
    }

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<UnitScript>().Unit.CurrentHealth -= damage;
        Object.Destroy(Projectile_go);
    }
}
