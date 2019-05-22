using UnityEngine;

public class WarLightScript : UnitScript
{
    void Start()
    {
        unit = new WarLight(gameObject.transform.parent.GetComponent<UnitScript>().Unit.Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarLight)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
