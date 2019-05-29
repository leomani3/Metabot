using UnityEngine;

public class WarExplorer : MovableUnit
{
    public WarExplorer(MetaTeam team, GameObject go,
        float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, 
        float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, 
        float armor = 1.0f) 
        : base(team, heading, go, maxHealth, speed, distanceSight, angleSight, maxBagSize, armor)
    {

    }
}
