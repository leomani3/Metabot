using UnityEngine;

public abstract class Projectile
{
    readonly float speed;
    readonly float damage;
    readonly float explosionRadius;
    float autonomy;
    GameObject projectile_go;
    Vector3 direction;

    protected Projectile(float speed, float damage, float explosionRadius, float autonomy)
    {
        this.speed = speed;
        this.damage = damage;
        this.explosionRadius = explosionRadius;
        this.autonomy = autonomy;
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
        autonomy -= Time.deltaTime;
        if (autonomy <= 0)
        {
            Object.Destroy(projectile_go);
        }
        else 
            this.projectile_go.transform.position += speed * direction.normalized * 0.2f;
    }

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<UnitController>().Unit.CurrentHealth -= damage;
        //Debug.Log(other.GetComponent<UnitController>().Unit.CurrentHealth);
        Object.Destroy(Projectile_go);
    }
}

public class LightBullet : Projectile
{
    public LightBullet(float speed = 10.0f, float damage = 20.0f, float explosionRadius = 0.5f, float autonomy = 3.0f) : base(speed, damage, explosionRadius, autonomy){}
}
