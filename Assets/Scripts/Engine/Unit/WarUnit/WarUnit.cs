using UnityEngine;

public abstract class WarUnit : Unit
{
    protected float armor;

    protected WarUnit(MetaTeam team,
        float heading, GameObject go, float maxHealth, float distanceSight,
        float angleSight, int maxBagSize, float armor)
        : base(team, heading, go, maxHealth, distanceSight, angleSight, maxBagSize)
    {
        this.armor = armor;
    }
}
