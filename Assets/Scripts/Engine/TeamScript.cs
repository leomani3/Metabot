using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScript : MonoBehaviour
{

    MetaTeam team;
    public List<Vector3> spawnPoints;

    private void Start()
    {
        foreach(Transform child in transform.GetChild(0))
        {
            spawnPoints.Add(child.transform.position);
        }
    }

    public MetaTeam Team
    {
        get {return team;}
        set{team = value;}
    }
}
