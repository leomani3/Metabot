using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarLight : WarUnit {

    public WarLight(float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float timeRoeload = 1.0f, float armor = 1.0f) :
        base(maxHealth, speed, distanceSight, angleSight, maxBagSize, heading, timeRoeload, armor) 
        {
        this.projectile = Resources.Load<GameObject>("Prefab/Item/Projectile/LightBullet");
        } 
}

public class WarExplorer : WarUnit
{

    public WarExplorer(float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float timeRoeload = 1.0f, float armor = 1.0f) :
        base(maxHealth, speed, distanceSight, angleSight, maxBagSize, heading, timeRoeload, armor)
    {
        this.projectile = null;
    }
}
