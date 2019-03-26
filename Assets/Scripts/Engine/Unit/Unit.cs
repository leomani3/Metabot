using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Percepts {

    readonly static float MAX_DISTANCE_GIVE = 5.0f;
    readonly static float MAX_DISTANCE_TAKE = 5.0f;

    readonly float maxHealth;
	float currentHealth;
    readonly float speed;
    readonly float distanceSight;
    readonly float angleSight;
    readonly int maxBagSize;
	int currentBagSize;
    ArrayList bag;
    float heading;
    protected GameObject unit_go;

	public Unit(float maxHealth, float speed, float distanceSight, float angleSight, int maxBagSize, float heading) {
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.speed = speed;
		this.distanceSight = distanceSight;
		this.angleSight = angleSight;
		this.maxBagSize = maxBagSize;
		this.currentBagSize = 0;
        this.heading = heading;
        this.bag = new ArrayList(maxBagSize);
	}

	public bool IsFullBag(){
		return this.currentBagSize == this.maxBagSize;
	}

    public bool IsEmptyBag()
    {
        return this.currentBagSize == 0;
    }

    public void take(Ressource r)
    {
        if (!IsFullBag() && Vector3.Distance(unit_go.transform.position, r.Ressource_go.transform.position) < MAX_DISTANCE_TAKE)
        {
            this.bag.Add(r);
            currentBagSize++;
            GameObject.Destroy(r.Ressource_go);
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
            for (int i = 0; i < currentBagSize ; i++)
            {
                Ressource r = (Ressource) bag[i];
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

    public void Move(Vector3 direction)
    {
        if (!IsBlocked())
            unit_go.transform.position += speed * direction.normalized * 0.2f;
        else
            unit_go.transform.position *= -1;//Faire quelque chose
    }
    
    public bool IsBlocked()
    {
        return false; // A faire
    }

    public float Heading
    {
        get { return this.heading; }
        set { this.heading = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { this.currentHealth = value; }
    }

    public GameObject Unit_go
    {
        get { return unit_go; }
        set { this.unit_go = value; }
    }

    public int Team
    {
        get { return this.team; }
        set { this.team = value; }
    }


}
