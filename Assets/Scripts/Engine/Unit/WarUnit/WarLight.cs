using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarLight : WarUnit
{

    //On donne la liste de features de l'unité
    private Movable movableFeature;
    private Weapon weaponFeature;
    private Creator creatorFeature;

    public WarLight(MetaTeam team, float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float timeReload = 1.0f, float armor = 1.0f) : base(maxHealth, distanceSight, angleSight, maxBagSize, heading, timeReload, armor, team)
    {
        this.projectile = Resources.Load<GameObject>("Prefab/Item/Projectile/LightBullet");

        this.weaponFeature = new Weapon(this, timeReload, projectile); //permet à l'unité de tirer
        this.movableFeature = new Movable(this, speed);    //permet à l'unité de bouger

        //On créer l'AL qui contient tous les type d'unité que je peux créer
        List<System.Type> al = new List<System.Type>();
        al.Add(typeof(WarLight));
        al.Add(typeof(WarExplorer));
        this.creatorFeature = new Creator(this, al);    //permet à l'unite de pouvoir créer d'autre unités. Il faut lui passer une AL en paramètres.
    }

    public void Shoot()
    {
        weaponFeature.Shoot();
    }

    public void Create()
    {
        creatorFeature.Create();
    }

    public void Move()
    {
        movableFeature.Move();
    }

    public Weapon WeaponFeature
    {
        get { return weaponFeature; }
    }

    public Movable MovableFeature
    {
        get { return movableFeature; }
    }

    public Creator CreatorFeature
    {
        get { return creatorFeature; }
    }
}
