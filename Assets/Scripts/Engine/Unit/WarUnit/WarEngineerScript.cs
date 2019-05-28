using UnityEngine;

public class WarEngineerScript : UnitScript
{
    void Start()
    {
        unit = new WarEngineer(gameObject.gameObject.transform.parent.GetComponent<UnitScript>().Unit.Team, gameObject);
    }
}