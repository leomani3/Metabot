using UnityEngine;

public abstract class WarUnit : Unit
{

    protected float timeReload;
    protected float reloading;
    protected float armor;
    protected GameObject projectile;

    protected WarUnit(float maxHealth, float speed, float distanceSight, float angleSight, int maxBagSize, float heading, float timeRoeload, float armor) : base(maxHealth,speed,distanceSight,angleSight,maxBagSize,heading)
    {
        this.timeReload = timeRoeload;
        this.armor = armor;
        this.reloading = 0;
    }

    public void shoot()
    {
        reloading -= Time.fixedDeltaTime;
        if(reloading <= 0)
        {
            Object.Instantiate(projectile, unit_go.transform.GetChild(2));
            reloading = timeReload;
        }
    }
}
