using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    protected WarUnit unit;

    public WarUnit Unit
    {
        get { return unit; }
    }

    // Use this for initialization
    void Start () {
        unit = new WarLight
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0,unit.Heading,0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {
        unit.GetAllPerceptsInRadius();
        if (unit.PerpecptsInSight.Count > 0)
            ;//unit.Shoot();
        else
            ;//unit.Move();
	}

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
