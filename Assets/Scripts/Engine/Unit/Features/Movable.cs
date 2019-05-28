using UnityEngine;

public class Movable : Feature
{
    protected readonly float speed;
    private string Target { get; set; }
    private float MAX_DISTANCE_TAKE_GIVE = 10.0f;

    public Movable(Unit unit, float speed) : base(unit)
    {
        this.speed = speed;
    }

    public void Move()
    {
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

    public void Take()
    {
        GameObject nearestRessources = unit.GetNearestRessource();
        if (!unit.IsFullBag() && Vector3.Distance(unit.Unit_go.transform.position, nearestRessources.transform.position) < MAX_DISTANCE_TAKE_GIVE)
        {
            unit.Bag.Add(nearestRessources);
            unit.CurrentBagSize++;
            Object.Destroy(nearestRessources);
        }
    }

    public void Give()
    {
        GameObject nearestRessources = unit.GetNearestRessource();//A changer par allié qui a le moins de vie 
        if (!unit.IsFullBag() && Vector3.Distance(unit.Unit_go.transform.position, nearestRessources.transform.position) < MAX_DISTANCE_TAKE_GIVE)
        {
            unit.Bag.Add(nearestRessources);
            unit.CurrentBagSize++;
            Object.Destroy(nearestRessources);
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
            case "base": //Base alliée
                break;
            case "baseEnemie": //Base enemie la plus proche (plusieurs base à 4 joueur)
                break;
        }
        if(go_target != null)
        {
            float angle = Utility.getAngle(unit.Unit_go.transform.position, unit.GetNearestEnemy().transform.position);
            unit.Heading = angle;
        }

        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

}
