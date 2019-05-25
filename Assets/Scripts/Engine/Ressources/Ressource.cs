using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ressource
{

    string name;
    int weight;
    public static float respawnTime;
    GameObject ressouce_go;

    public Ressource(string name, int weight)
    {
        this.name = name;
        this.weight = weight;
    }

    public string Name
    {
        get { return this.name; }
    } 

    public GameObject Ressource_go
    {
        get { return ressouce_go; }
    }

    public abstract void UseRessource(Unit unit);

}

