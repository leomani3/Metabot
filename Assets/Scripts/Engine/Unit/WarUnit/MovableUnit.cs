using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MovableUnit : WarUnit
{
    private Movable movableFeature;

    public MovableUnit(MetaTeam team, 
        float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, 
        float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float armor = 1.0f) 
        : base(team, maxHealth, distanceSight, angleSight, maxBagSize, heading, armor)
    {
        this.movableFeature = new Movable(this, speed);    //permet à l'unité de bouger
    }

    public void Move()
    {
        movableFeature.Move();
    }

    public Movable MovableFeature
    {
        get { return movableFeature; }
    }
}
