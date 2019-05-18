using UnityEngine;

public class WarEngineerScript : UnitScript
{
    void Start()
    {
        unit = new WarEngineer(gameObject.GetComponentInParent<WorldTest>().TeamRed)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarEngineer)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}