using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Feature
{
    protected float timeReload;
    protected float timeBeforeReload;
    protected GameObject projectile_go;

    protected Weapon(float timeReload, float timeBeforeReload, GameObject projectile_go, Unit unit) : base(unit)
    {
        this.timeReload = timeReload;
        this.timeBeforeReload = timeBeforeReload;
        this.projectile_go = projectile_go;
    }

    public void Shoot()
    {
        if (projectile_go != null)
        {
            timeBeforeReload -= Time.fixedDeltaTime;
            if (timeBeforeReload <= 0)
            {
                Object.Instantiate(projectile_go, unit.Unit_go.transform.GetChild(2).position, Quaternion.Euler(0, unit.Heading, 0));
                timeBeforeReload = timeReload;
            }
        }
    }
}
