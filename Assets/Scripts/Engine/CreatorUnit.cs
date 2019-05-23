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

    public void Create(string name, MetaTeam team)
    {
        Debug.Log("Unit " + name + " créée");
        
        switch (name)
        {
            case "Light":
                WarLight wl = new WarLight(team);
                break;
            case "Explorer":
                WarExplorer we = new WarExplorer(team);
                break;
            case "Heavy":
                WarHeavy wh = new WarHeavy(team,angleSpawn);
                break;
            case "Engineer":
                WarEngineer weg = new WarEngineer(team);
                break;
            case "Base":
                WarBase wb = new WarBase(team);
                break;
            default:
                break;
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
