using UnityEngine;

public class UnitScript : MonoBehaviour
{
    protected Unit unit;
    bool hpBarSpawn = false;


    void Update()
    {
        //Debug.DrawRay(unit.Unit_go.transform.position, Utility.vectorFromAngle(unit.Heading).normalized * unit.DistanceSight, Color.red, 0.1f);
        //Debug.DrawRay(unit.Unit_go.transform.position, Utility.vectorFromAngle(unit.Heading - unit.AngleSight / 2).normalized * unit.DistanceSight, Color.red, 0.1f);
        //Debug.DrawRay(unit.Unit_go.transform.position, Utility.vectorFromAngle(unit.Heading + unit.AngleSight / 2).normalized * unit.DistanceSight, Color.red, 0.1f);
        if (unit.GetType() == typeof(WarBase))
            Debug.Log(unit.GetType().ToString() + " " + unit.Team.teamColor + " : " + unit.CurrentHealth);

        unit.GetAllPerceptsInRadius();
        unit.Brain.decide(unit);

        if(unit.NextAction != null)
        {
            unit.RunAction();
            unit.NextAction = null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        unit.OnCollisionEnter(other);
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }

    public Unit Unit
    {
        get { return unit; }
    }
}

