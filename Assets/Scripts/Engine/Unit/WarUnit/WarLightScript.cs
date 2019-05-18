using UnityEngine;

public class WarLightScript : UnitScript
{
    void Start()
    {
        unit = new WarLight(gameObject.GetComponentInParent<WorldTest>().TeamRed)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, unit.Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
