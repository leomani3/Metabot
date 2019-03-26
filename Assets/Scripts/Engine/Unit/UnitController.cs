using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    WarUnit unit;

	// Use this for initialization
	void Start () {
        unit = new WarLight
        {
            Unit_go = gameObject
        };

        foreach (MeshRenderer meshRenderer in unit.Unit_go.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {
        unit.Move(new Vector3(1, 0, 0));
        unit.shoot();
	}
}
