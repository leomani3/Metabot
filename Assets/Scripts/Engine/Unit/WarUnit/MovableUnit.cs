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
        this.movableFeature = new Movable(this, speed);
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

    public new void OnCollisionEnter(Collision other)
    {
        collisionObject = null;
        if (other.collider.tag != "Ground" && other.collider.gameObject.tag != "Item")
        {
            collisionObject = other.collider.transform.gameObject;
            Heading = (Heading + Random.Range(135, 215)) % 360;
            Vector3 dir = Utility.vectorFromAngle(Heading);
            //Unit_go.GetComponent<Rigidbody>().MovePosition(Unit_go.transform.position + (dir * movableFeature.Speed * Time.deltaTime));
            //Unit_go.transform.position += dir * movableFeature.Speed * Time.deltaTime;
        }
    }
}
