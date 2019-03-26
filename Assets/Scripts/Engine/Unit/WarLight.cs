using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarLight : WarUnit {

    public static WarLight WAR_LIGHT = new WarLight(200, 1.8f, 20.0f, 90.0f, 5, 45.0f, 1.0f, 1.0f, Projectile.LIGHT_BULLET);

    public WarLight(float maxHealth, float speed, float distanceSight, float angleSight, int maxBagSize, float heading, float timeRoeload, float armor, Projectile projectile) :
        base(maxHealth, speed, distanceSight, angleSight, maxBagSize, heading, timeRoeload, armor, projectile) { } 
}
