using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MovableUnit : WarUnit
{
    private Movable movableFeature;
    private float heading;
    
    public MovableUnit(MetaTeam team, float heading, 
        float maxHealth, float speed, float distanceSight, 
        float angleSight, int maxBagSize,
        float armor)
        : base(team, maxHealth, distanceSight, angleSight, maxBagSize, armor)
    {
        this.heading = heading;
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

    public float Heading
    {
        get { return this.heading; }
        set { this.heading = value; }
    }
}
