using UnityEngine;

public class WarEngineerScript : UnitScript
{
    void Start()
    {
        unit = new WarEngineer(gameObject.gameObject.transform.parent.GetComponent<UnitScript>().Unit.Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarEngineer)unit).Heading, 0).eulerAngles);

        Color color = Color.white;
        switch (unit.Team.name)
        {
            case "Red":
                //TODO : à la place de changer la couleur il faut load le bon asset
                color = Color.red;
                break;
            case "Blue":
                color = Color.blue;
                break;
        }

        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarEngineer)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}