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
            Projectile_go = gameObject,
            Direction = new Vector3(1, 0, 0)
        };
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
}
