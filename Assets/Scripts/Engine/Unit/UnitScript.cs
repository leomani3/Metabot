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
        if(Unit != null)
        {
            Unit.GetAllPerceptsInRadius();
            unit.Brain.decide(unit);
            unit.RunAction();
        }
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}

