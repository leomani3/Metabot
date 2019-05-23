using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorUnit : MonoBehaviour
{
    public Transform[] _spawnPoint;
    public GameObject[] _unitsToCreate;
    private float angleSpawn;
    private int distanceSpawn;


    // Use this for initialization
    void Awake () {
        angleSpawn = Random.Range(0f, 360f);
        distanceSpawn = Random.Range(8, 15);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create(string name, GameObject team, GameObject color, int teamId)
    {
        //Debug.Log("Unit " + name + " créée");
        //Debug.Log(name);
        Vector3 positionBase = new Vector3(-36.2f, 4f, -37.4f);
        if (teamId == 2)
            positionBase = new Vector3(35.8f, 4f, 40f);
        if (teamId == 3)
            positionBase = new Vector3(40f, 4f, -23.9f);
        if (teamId == 4)
            positionBase = new Vector3(-35.6f, 4f, 31.7f);
        int random = Random.Range(0, 5);

        Vector3 positionUnit = new Vector3(positionBase.x + 1 + random, 1, positionBase.z + 5 + random);

        if (name.Equals("Base"))
        {
            GameObject preloadB = Resources.Load<GameObject>("Prefab/Unit/WarBase");
            preloadB.SetActive(true);
            color = Instantiate(preloadB, positionBase, Quaternion.identity, team.transform);
        }
        else
        {
            GameObject preload = Resources.Load<GameObject>("Prefab/Unit/War" + name);
            preload.SetActive(true);
            color = Instantiate(preload, positionUnit, Quaternion.identity, team.transform);
        }
    }

    public void Create(string name)
    {
        
        
        GameObject target = null;
        foreach (GameObject _unit in _unitsToCreate)
        {
            if (_unit.GetComponent<Stats>()._unitType.Equals(name))
            {
                target = _unit;
            }
        }

        Vector3 unitSpawnPosition = transform.position + distanceSpawn * new Vector3(Mathf.Cos(angleSpawn * Mathf.Deg2Rad), 0, Mathf.Sin(angleSpawn * Mathf.Deg2Rad));
        angleSpawn += 15;

        if( angleSpawn > 360)
        {
            angleSpawn = angleSpawn % 360;
            distanceSpawn = ((distanceSpawn + 1) % 7) + 8;
        }

        // GameObject unit = Instantiate(target,transform.parent);
        //GameObject unit = Instantiate(target, unitSpawnPosition, Quaternion.identity, transform.parent);
        GameObject unit = ObjectPool.Pick(name);
        unit.transform.parent = gameObject.transform.parent;
        unit.transform.position = unitSpawnPosition;
        unit.transform.position = new Vector3(unit.transform.position.x, _spawnPoint[0].position.y, unit.transform.position.z);
        transform.parent.GetComponent<TeamPlayManagerScript>().UpdateUnit();
        unit.GetComponent<Stats>()._teamIndex = GetComponent<Stats>()._teamIndex;
        
    }
}
