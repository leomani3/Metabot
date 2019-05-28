using UnityEngine;

public class Movable : Feature
{
    protected readonly float speed;
    public string Target { get; set; }
    private float MAX_DISTANCE_TAKE_GIVE = 10.0f;

    public Movable(Unit unit, float speed) : base(unit)
    {
        this.speed = speed;
    }

    public void Move()
    {
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

    public void RandomMove()
    {
        unit.Heading = (unit.Heading + Random.Range(-5, 5)) % 360;
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

    public void Take()
    {
        GameObject nearestRessources = unit.GetNearestRessource();
        if (nearestRessources != null && !unit.IsFullBag())
        {
            if (Vector3.Distance(unit.Unit_go.transform.position, nearestRessources.transform.position) <= MAX_DISTANCE_TAKE_GIVE)
            {
                lock (nearestRessources)
                {
                    if (nearestRessources != null)
                    {
                        unit.Bag.Add(nearestRessources.GetComponent<ResourcesScript>().Ressource);
                        unit.CurrentBagSize += 1;
                        unit.RessourcesInSight.Remove(nearestRessources);
                        Object.Destroy(nearestRessources);
                    }
                }
            }
            else
            {
                float angle = Utility.getAngle(unit.Unit_go.transform.position, nearestRessources.transform.position);
                unit.Heading = angle;
                Move();
            }
        }
    }

    public void Give()
    {
        Debug.Log("GIVE ME THAT");
        GameObject nearestAllie = unit.BaseAllie;//A changer par allié qui a le moins de vie 
        if (nearestAllie != null && !unit.IsEmptyBag() && !nearestAllie.GetComponent<UnitScript>().Unit.IsFullBag())
        {
            if (Vector3.Distance(unit.Unit_go.transform.position, nearestAllie.transform.position) < MAX_DISTANCE_TAKE_GIVE)
            {
                nearestAllie.GetComponent<UnitScript>().Unit.Bag.Add(unit.Bag[0]);
                nearestAllie.GetComponent<UnitScript>().Unit.CurrentBagSize += 1;
                unit.Bag.RemoveAt(0);
                unit.CurrentBagSize -= 1;
                Debug.Log("GIVE");
            }
            else
            {
                float angle = Utility.getAngle(unit.Unit_go.transform.position, nearestAllie.transform.position);
                unit.Heading = angle;
                Move();
            }
        }
    }

    public void MoveTo()
    {
        GameObject go_target = null;
        switch (Target)
        {
            case "allie":
                go_target = unit.GetNearestAllies();
                break;
            case "enemie":
                go_target = unit.GetNearestEnemy(); 
                break;
            case "resource":
                go_target = unit.GetNearestRessource();
                break;
            case "base":
                go_target = unit.BaseAllie;
                break;
            case "baseEnemie": //Base enemie la plus proche (plusieurs base à 4 joueur)
                break;
        }
        if(go_target != null)
        {
            float angle = Utility.getAngle(unit.Unit_go.transform.position, go_target.transform.position);
            unit.Heading = angle;
        }

        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

}
