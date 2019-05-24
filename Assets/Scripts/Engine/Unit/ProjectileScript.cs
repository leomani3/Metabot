using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    Projectile projectile;
	// Use this for initialization
	void Start () 
    {
        projectile = new LightBullet()
        {
            Projectile_go = gameObject
        };
        projectile.Direction = Utility.vectorFromAngle(projectile.Projectile_go.transform.eulerAngles.y);
    }

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
