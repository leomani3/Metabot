using UnityEngine;

public abstract class MovableUnit : WarUnit
{
    private Movable movableFeature;
    
    public MovableUnit(MetaTeam team, 
        float heading, GameObject go, float maxHealth, float speed, 
        float distanceSight, float angleSight, int maxBagSize,
        float armor)
        : base(team, heading, go, maxHealth, distanceSight, angleSight, maxBagSize, armor)
    {
        this.heading = heading;
        this.movableFeature = new Movable(this, speed);    //permet à l'unité de bouger
    }

    public void Move()
    {
        movableFeature.Move();
    }

    public void Take()
    {
        movableFeature.Take();
    }

    public void Give()
    {
        movableFeature.Give();
    }

    public void MoveTo()
    {
        movableFeature.MoveTo();
    }

    public Movable MovableFeature
    {
        get { return movableFeature; }
    }
}
