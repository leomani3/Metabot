using UnityEngine;

public abstract class WarUnit : Unit
{
    protected float armor;

    protected WarUnit(MetaTeam team, 
        float maxHealth, float distanceSight, float angleSight, 
        int maxBagSize, float armor ) 
        : base(team, maxHealth, distanceSight, angleSight, maxBagSize)
    {
        this.armor = armor;
    }
}
