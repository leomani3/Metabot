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
        unit.GetAllPerceptsInRadius();
        unit.Brain.decide(unit);
        if(unit.NextAction != null)
        {
            unit.RunAction();
            unit.NextAction = null;
        }
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}

