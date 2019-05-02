using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarLightScript : UnitScript
{

    // Use this for initialization
    void Start()
    {
        unit = new WarLight
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, unit.Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Unit.GetAllPerceptsInRadius();
        if (Input.GetMouseButtonDown(0))
        {
            ((WarLight)unit).CreatorFeature.Type = System.Type.GetType("WarLight");
            ((WarLight)unit).CreatorFeature.Create();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ((WarLight)unit).CreatorFeature.Type = typeof(WarExplorer);
            ((WarLight)unit).CreatorFeature.Create();
        }
        if (unit.PerpeptsInSight.Count > 0)
            ((WarLight)unit).WeaponFeature.Shoot();
        else
            ((WarLight)unit).MovableFeature.Move();
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
