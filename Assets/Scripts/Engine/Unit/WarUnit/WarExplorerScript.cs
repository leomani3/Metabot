using UnityEngine;

public class WarExplorerScript : UnitScript
{
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<UnitScript>().Unit.Team)
        {
            Unit_go = gameObject
        };

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

        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarExplorer)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}
