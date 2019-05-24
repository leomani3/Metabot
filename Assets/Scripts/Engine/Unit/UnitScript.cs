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
        if (Unit.PerceptsInSight.Count > 0)
        {
            Color MyColour = Color.clear; ColorUtility.TryParseHtmlString(Unit.Team.teamName, out MyColour);
            //Debug.DrawLine(gameObject.transform.position, ((GameObject)Unit.PerceptsInSight[0]).transform.position, MyColour, 1);
        }
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

