using UnityEngine;

public class WarEngineerScript : UnitScript
{
    void Start()
    {
        unit = new WarEngineer(gameObject.GetComponentInParent<UnitScript>().Unit.Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarEngineer)unit).Heading, 0).eulerAngles);

        Color color = Color.white;
        switch (unit.Team.name)
        {
            case "Red":
                color = Color.red;
                break;
            case "Blue":
                color = Color.blue;
                break;
        }

        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}