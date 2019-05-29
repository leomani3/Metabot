using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour {

    protected Projectile projectile;

    // Update is called once per frame
    void FixedUpdate() 
    {
        projectile.Move();
	}

    void OnTriggerEnter(Collider other)
    {
        projectile.OnTriggerEnter(other);
    }

    void OnCollisionExit(Collision other)
    {
        OnCollisionExit(other);
    }

    public Projectile Projectile
    {
        get
        {
            return projectile;
        }
    }
}
