using System;
using UnityEngine;

public abstract class WarUnit : Unit
{

    float timeReload;
    float armor;
    Projectile projectile;

    public WarUnit(float maxHealth, float speed, float distanceSight, float angleSight, int maxBagSize, float heading, float timeRoeload, float armor, Projectile projectile) : base(maxHealth,speed,distanceSight,angleSight,maxBagSize,heading)
    {
        this.projectile = projectile;
        this.timeReload = timeRoeload;
        this.armor = armor;
    }

    public void shoot(Vector3 direction)
    {
        if(timeReload <= 0)
        {
            projectile.Direction = direction;
            GameObject.Instantiate(projectile.Projectile_go, unit_go.transform);
        }
    }
}
