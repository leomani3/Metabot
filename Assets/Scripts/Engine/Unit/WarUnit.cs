using UnityEngine;

public abstract class WarUnit : Unit
{
    protected float armor;
    protected GameObject projectile;

    protected WarUnit(float maxHealth, float distanceSight, float angleSight, int maxBagSize, float heading, float timeRoeload, float armor) : base(maxHealth,distanceSight,angleSight,maxBagSize,heading)
    {
        this.armor = armor;
    }
}
