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
            if(other.collider.tag == "Unit")
            {
                collisionObject = other.collider.transform.gameObject;
                Heading = (Heading + Random.Range(135, 215)) % 360;
                Vector3 dir = Utility.vectorFromAngle(Heading);
                Move();
                /*Unit_go.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                Unit_go.GetComponent<Rigidbody>().MovePosition(Unit_go.transform.position + (dir * movableFeature.Speed * 0.2f));*/
            }
            else
            {
                Vector3 vecAxe;
                if (other.collider.bounds.size.x > other.collider.bounds.size.z)
                {
                    vecAxe = new Vector3(other.collider.bounds.size.x, 0, 0);
                }
                else
                {
                    vecAxe = new Vector3(0, 0, other.collider.bounds.size.z);
                }
                Vector3 N = Vector3.Cross(Vector3.Normalize(vecAxe), Vector3.up);
                Vector3 L = this.Unit_go.transform.position - other.transform.position;
                Vector3 reflect = 2 * Vector3.Dot(N, L) * N - L;

                Heading = Utility.getAngle(Unit_go.transform.position, Unit_go.transform.position + Vector3.Normalize(reflect));
                Move();
            }
        }
    }

    public new void OnCollisionStay(Collision other)
    {
        if(other.collider.tag != "Unit")
        {
            Vector3 res = Vector3.zero;
            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");

            foreach (GameObject go in units)
            {
                res += go.transform.position;
            }
            res *= 1f / (units.Length + 1);
            float angle = Utility.getAngle(unit_go.transform.position, res);
            this.Heading = angle;
            Move();
        }
    }
}
