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
        unit.Unit_go.transform.Rotate(Quaternion.Euler(0,unit.Heading,0).eulerAngles);
        foreach (MeshRenderer meshRenderer in unit.Unit_go.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {
        unit.Move();
        unit.Shoot();
	}

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }
}
