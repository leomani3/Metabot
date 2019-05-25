using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
    readonly static float MAX_DISTANCE_GIVE = 5.0f;
    readonly static float MAX_DISTANCE_TAKE = 5.0f;

    public delegate void Action();

    protected GameObject collisionObject;
    protected GameObject unit_go;

    protected MetaTeam team;

    protected readonly float maxHealth;
    protected float currentHealth;

    protected readonly float distanceSight;
    protected readonly float angleSight;
    protected float heading;

    protected readonly int maxBagSize;
    protected int currentBagSize;
    protected ArrayList bag;

    protected ArrayList perceptsInSight;
    protected ArrayList enemiesInSight;
    protected ArrayList alliesInSight;
    protected ArrayList ressourcesInSight;

    protected MetaBrain brain;
    protected Action nextAction;

    protected Dictionary<string, float> dico;

    protected Unit(MetaTeam team, float heading, float maxHealth, float distanceSight, float angleSight,
        int maxBagSize)
    {
        this.heading = heading;
        this.team = team;
        if (team.brains.ContainsKey(this.GetType().ToString())) {
            this.brain = team.brains[this.GetType().ToString()];
        }
        else {
            //Ajouter un comportement par defaut à l'unit ?
        }

        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.distanceSight = distanceSight;
        this.angleSight = angleSight;
        this.maxBagSize = maxBagSize;
        this.currentBagSize = 0;
        this.bag = new ArrayList(maxBagSize);
        this.perceptsInSight = new ArrayList();
        this.enemiesInSight = new ArrayList();
        this.alliesInSight = new ArrayList();
        this.ressourcesInSight = new ArrayList();
        dico = new Dictionary<string, float>
        {
            { "maxHealth", MaxHealth },
            { "currentHealth", CurrentHealth },
            { "distanceSight", DistanceSight },
            { "angleSight", AngleSight },
            { "maxBagSize", MaxBagSize },
            { "currentBagSize", CurrentBagSize },
            { "heading", Heading },
            { "perceptsCount", perceptsInSight.Count },
            { "enemiesCount", enemiesInSight.Count },
            { "ressourceCount", ressourcesInSight.Count},
            { "alliesCount", alliesInSight.Count}
        };
    }

    public void RunAction()
    {
        nextAction();
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

    public void OnCollisionEnter(Collision other)
    {

    }

    public void OnCollisionStay(Collision other)
    {
        collisionObject = null;
        if(other.collider.tag != "Ground" && this.GetType() != typeof(WarBase))
        {
            collisionObject = other.collider.transform.gameObject;
            Heading = (Heading + Random.Range(160, 340)) % 360;
        }
        //--source--
        //if (other.gameObject.tag != "Ground")
        //{
        //    foreach (ContactPoint contact in other.contacts)
        //    {
        //        float a = Utility.getAngle(unit_go.transform.position, contact.point);
        //        float A = Mathf.Abs(a - heading);
        //        float B = Mathf.Abs(360 + Mathf.Min(a, heading) - Mathf.Max(a, heading));
        //        if (Mathf.Min(A, B) < 90f)
        //        {
        //            collisionObject = other.transform.gameObject;
        //            heading = (Mathf.Min(A, B) + 180.0f) % 360.0f;
        //            break;
        //        }
        //    }
        //}
    }

    public void OnCollisionExit(Collision other)
    {
        collisionObject = null;
    }

    public void GetAllPerceptsInRadius()
    {
        perceptsInSight.Clear();
        enemiesInSight.Clear();
        Collider[] colliders = Physics.OverlapSphere(unit_go.transform.position, distanceSight);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer("Percepts")) && !collider.gameObject.Equals(unit_go))
            {
                float angle = Utility.getAngle(unit_go.transform.position, collider.gameObject.transform.position);
                
                if (angle > (heading - (angleSight / 2)) && angle < (heading + (angleSight / 2)))
                {
                    perceptsInSight.Add(collider.gameObject);
                    if (collider.gameObject.tag == "Unit" && collider.gameObject.GetComponentInParent<TeamScript>().Team.teamName != Team.teamName)
                    {
                        enemiesInSight.Add(collider.gameObject);
                    } else if(collider.gameObject.tag == "Unit" && collider.gameObject.GetComponentInParent<TeamScript>().Team.teamName == Team.teamName)
                    {
                        alliesInSight.Add(collider.gameObject);
                    }
                }
            }
        }
        dico["perceptsCount"] = perceptsInSight.Count;
        dico["enemiesCount"] = enemiesInSight.Count;
    }

    public GameObject GetNearestEnemie()
    {
        GameObject go = (GameObject)enemiesInSight[0];
        float distMin = 0.0f;
        for (int i = 1; i < enemiesInSight.Count; i++)
        {
            float dist = Vector3.Distance(unit_go.transform.position, ((GameObject)enemiesInSight[i]).transform.position);
            if (dist < distMin)
            {
                go = (GameObject)enemiesInSight[i];
                distMin = dist;
            }
        }
        return go;
    }

    public float LookUp(string key)
    {
        string[] res = key.Split((" ").ToCharArray());
        float tmp = 0.0f;
        if(res.Length > 1)
        {
            switch (res[1])
            {
                case "*":
                    tmp = LookUp(res[0]) * LookUp(res[2]);
                    break;
                case "/":
                    tmp = LookUp(res[0]) / LookUp(res[2]);
                    break;
                case "+":
                    tmp = LookUp(res[0]) + LookUp(res[2]);
                    break;
                case "-":
                    tmp = LookUp(res[0]) - LookUp(res[2]);
                    break;
            }
        }
        else
        {
            if (float.TryParse(key, out tmp))
            {
                return tmp;
            }
            tmp = dico[key];
        }
        return tmp;
    }

    public bool IsBlocked()
    {
        return collisionObject != null;
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            this.currentHealth = value;
            dico["currentHealth"] = value;
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

    public float DistanceSight
    {
        get
        {
            return distanceSight;
        }
    }

    public ArrayList PerceptsInSight
    {
        get
        {
            return perceptsInSight;
        }
    }

    public Action NextAction
    {
        get
        {
            return nextAction;
        }
        set
        {
            nextAction = value;
        }
    }

    public MetaBrain Brain
    {
        get
        {
            return brain;
        }
    }

    public virtual float Heading
    {
        get
        {
            return heading;
        }

        set
        {
            heading = value;
            Unit_go.transform.rotation = Quaternion.AngleAxis(Heading, Vector3.up);
        }
    }

    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }
    }

    public float AngleSight
    {
        get
        {
            return this.angleSight;
        }
    }

    public MetaTeam Team
    {
        get
        {
            return team;
        }
    }

    public float MaxBagSize
    {
        get
        {
            return this.maxBagSize;
        }
    }

    public GameObject CollisionObject
    {
        get { return collisionObject; }
    }

    public int CurrentBagSize
    {
        get
        {
            return this.currentBagSize;
        }

        set
        {
            this.currentBagSize = value;
        }
    }
}
