using UnityEngine;

public abstract class WarUnit : Unit
{
    protected float armor;
    protected GameObject projectile;

    protected WarUnit(MetaTeam team, float maxHealth, float distanceSight, float angleSight, 
        int maxBagSize, float heading, 
        float armor ) 
        : base(maxHealth, distanceSight, angleSight, maxBagSize, heading, team)
    {
        this.armor = armor;
    }
}
