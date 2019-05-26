using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Feature
{
    protected float timeReload;
    protected GameObject projectile_go;

    private float timeBeforeReload;

    public Weapon(Unit unit, float timeReload, GameObject projectile_go) : base(unit)
    {
        this.timeReload = timeReload;
        this.timeBeforeReload = 0;
        this.projectile_go = projectile_go;
    }

    public void Shoot()
    {

        if (projectile_go != null)
        {
            timeBeforeReload -= Time.fixedDeltaTime;
            if (timeBeforeReload <= 0)
            {
                GameObject nearestEnemy = unit.GetNearestEnemy();
                float angle = Utility.getAngle(unit.Unit_go.transform.position, nearestEnemy.transform.position);
                unit.Heading = angle;

                Object.Instantiate(projectile_go, unit.Unit_go.transform.GetChild(2).position, Quaternion.Euler(0, unit.Heading, 0));
                timeBeforeReload = timeReload;
            }
        }
    }
}
