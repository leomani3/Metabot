using UnityEngine;

public class UnitScript : MonoBehaviour
{
    protected Unit unit;

    public Unit Unit
    {
        get { return unit; }
    }

    void Update()
    {
        Unit.GetAllPerceptsInRadius();
        if (unit.PerpeptsInSight.Count > 0)
            ;
        else
            ;
        
        unit.Brain.decide(unit);
        unit.RunAction();
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
