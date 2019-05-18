using UnityEngine;

public class WarHeavy : MovableUnit
{

    private Weapon weapon;
    public WarHeavy(MetaTeam team, float heading, float speed = 0.8f, float maxHealth = 800.0f, float distanceSight = 40.0f, float angleSight = 120.0f, int maxBagSize = 4, float timeToReload = 5.0f, float armor = 20.0f) : base (team,heading)
    {
        this.projectile = Resources.Load<GameObject>("Prefab/Item/Projectile/HeavyBullet");
        this.weapon = new Weapon(this, timeToReload, projectile);
    }

    public void Shoot()
    {
        weapon.Shoot();
    }
}
