using UnityEngine;

public class WarBaseScript : UnitScript
{
    void Start()
    {
        unit = new WarBase(gameObject.GetComponentInParent<WorldTest>().TeamRed)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, 0, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
