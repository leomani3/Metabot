using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{

    readonly static float MAX_DISTANCE_GIVE = 5.0f;
    readonly static float MAX_DISTANCE_TAKE = 5.0f;

    protected readonly float maxHealth;
    protected float currentHealth;
    protected readonly float distanceSight;
    protected readonly float angleSight;
    protected readonly int maxBagSize;
    protected int currentBagSize;
    protected float heading;
    protected GameObject unit_go;
    protected ArrayList bag;
    protected GameObject collisionObject;
    protected ArrayList perpecptsInSight;

    protected Unit(float maxHealth, float distanceSight, float angleSight, int maxBagSize, float heading)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.distanceSight = distanceSight;
        this.angleSight = angleSight;
        this.maxBagSize = maxBagSize;
        this.currentBagSize = 0;
        this.heading = heading;
        this.bag = new ArrayList(maxBagSize);
        this.perpecptsInSight = new ArrayList();
    }

    public bool IsFullBag()
    {
        return currentBagSize == maxBagSize;
    }

    public bool IsEmptyBag()
    {
        return currentBagSize == 0;
    }

    public void Take(Ressource r)
    {
        if (!IsFullBag() && Vector3.Distance(unit_go.transform.position, r.Ressource_go.transform.position) < MAX_DISTANCE_TAKE)
        {
            bag.Add(r);
            currentBagSize++;
            Object.Destroy(r.Ressource_go);
        }
        else
        {
            Debug.Log("Sac plein");
        }
    }

    public bool Use(string nameRessource)
    {
        if (!IsEmptyBag())
        {
            for (int i = 0; i < currentBagSize; i++)
            {
                Ressource r = (Ressource)bag[i];
                if (r.Name.Equals(nameRessource))
                {
                    bag.RemoveAt(i);
                    currentBagSize--;
                    r.UseRessource();
                    return true;
                }
            }
        }
        return false;
    }

    public void OnCollisionStay(Collision other)
    {
        collisionObject = null;
        if (other.gameObject.tag != "Ground")
        {
            foreach (ContactPoint contact in other.contacts)
            {
                float a = Utility.getAngle(unit_go.transform.position, contact.point);
                float A = Mathf.Abs(a - heading);
                float B = Mathf.Abs(360 + Mathf.Min(a, heading) - Mathf.Max(a, heading));
                if (Mathf.Min(A, B) < 90f)
                {
                    collisionObject = other.transform.gameObject;
                    break;
                }
            }
        }
    }

    public void GetAllPerceptsInRadius()
    {
        perpecptsInSight.Clear();
        Collider[] colliders = Physics.OverlapSphere(unit_go.transform.position, distanceSight);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer("Percepts")) && !collider.gameObject.Equals(unit_go))
            {
                perpecptsInSight.Add(collider);
                Debug.DrawLine(collider.transform.position, unit_go.transform.position);
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        collisionObject = null;
    }

    public bool IsBlocked()
    {
        return collisionObject != null;
    }

    public float Heading
    {
        get { return this.heading; }
        set { this.heading = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            this.currentHealth = value;
            if (this.CurrentHealth <= 0)
            {
                Object.Destroy(Unit_go);
            }
        }
    }

    public GameObject Unit_go
    {
        get { return unit_go; }
        set { this.unit_go = value; }
    }

    //Léo : J'ai mis ça en commentaire suite à la suppression de la classe Percept (qui gérait la couleur des équipe)
    /*public Color TeamColor
    {
        get { return this.teamColor; }
        set
        {
            this.teamColor = value;
            unit_go.transform.Rotate(Quaternion.Euler(0, heading, 0).eulerAngles);
        }
    }*/

    public float DistanceSight
    {
        get
        {
            return distanceSight;
        }
    }

    public ArrayList PerpecptsInSight
    {
        get
        {
            return perpecptsInSight;
        }
    }
}
