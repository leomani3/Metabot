using UnityEngine;

public abstract class MovableUnit : WarUnit
{
    private Movable movableFeature;
    
    public MovableUnit(MetaTeam team, 
        float heading, float maxHealth, float speed, 
        float distanceSight, float angleSight, int maxBagSize,
        float armor)
        : base(team, heading, maxHealth, distanceSight, angleSight, maxBagSize, armor)
    {
        this.heading = heading;
        this.movableFeature = new Movable(this, speed);
    }

    public void Move()
    {
        movableFeature.Move();
    }

    public void Take(Ressource r)
    {
        if (!IsFullBag() && Vector3.Distance(unit_go.transform.position, r.Ressource_go.transform.position) < Unit.MAX_DISTANCE_TAKE)
        {
            bag.Add(r);
            currentBagSize++;
            Object.Destroy(r.Ressource_go);
        }
    }

    public Movable MovableFeature
    {
        get { return movableFeature; }
    }

    public new void OnCollisionStay(Collision other)
    {
        collisionObject = null;
        if (other.collider.tag != "Ground" && other.collider.gameObject.tag != "Item")
        {
            collisionObject = other.collider.transform.gameObject;
            float angle = Utility.getAngle(Unit_go.transform.position, other.collider.transform.position);
            Heading = (angle + 180) % 360;
            movableFeature.Move();
        }
    }
}
