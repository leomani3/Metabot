using UnityEngine;

public class WarLight : MovableUnit
{

    //On donne la liste de features de l'unité
    private Weapon weaponFeature;
    protected GameObject projectile;

    public WarLight(MetaTeam team, 
        float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, 
        float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, 
        float timeReload = 1.0f, float armor = 1.0f) 
        : base(team, heading, maxHealth, speed, distanceSight, angleSight, maxBagSize, armor)
    {
        projectile = Resources.Load<GameObject>("Prefab/Item/Projectile/LightBullet");
        weaponFeature = new Weapon(this, timeReload, projectile); //permet à l'unité de tirer
    }

    public void Shoot()
    {
        weaponFeature.Shoot();
    }

    public Weapon WeaponFeature
    {
        get { return weaponFeature; }
    }

}
