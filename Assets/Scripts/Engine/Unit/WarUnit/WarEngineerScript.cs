using UnityEngine;

public class WarEngineerScript : MovableUnitScript
{
    void Start()
    {
        unit = new WarEngineer(gameObject.gameObject.transform.parent.GetComponent<UnitScript>().Unit.Team, gameObject);
    }
}