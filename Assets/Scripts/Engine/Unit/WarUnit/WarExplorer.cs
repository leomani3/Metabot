using UnityEngine;

public class WarExplorer : WarUnit
{

    public WarExplorer(MetaTeam team, float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float timeReload = 1.0f, float armor = 1.0f) 
        : base(maxHealth, distanceSight, angleSight, maxBagSize, heading, timeReload, armor, team)
    {
        this.projectile = null;
    }
}
