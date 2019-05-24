using UnityEngine;

public class WarExplorerScript : UnitScript
{
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<TeamScript>().Team)
        {
            Unit_go = gameObject
        };

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

        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarExplorer)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}
