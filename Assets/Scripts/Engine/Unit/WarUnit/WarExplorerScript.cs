using UnityEngine;

public class WarExplorerScript : UnitScript
{
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<UnitScript>().Unit.Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarExplorer)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
