using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ressource
{

    string name;
    int weight;
    float respawnTime;

    public Ressource(string name, int weight, float respawnTime)
    {
        this.name = name;
        this.weight = weight;
        this.respawnTime = respawnTime;
    }

    public string Name
    {
        get { return this.name; }
    } 

}

