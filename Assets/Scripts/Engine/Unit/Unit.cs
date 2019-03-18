﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit {

	float maxHealth;
	float currentHealth;
	float speed;
	float distanceSight;
	float angleSight;
	int maxBagSize;
	int currentBagSize;
    Ressource[] bag;
    int team;
    float heading;
    GameObject unit; // Pour bouger les unité dans une méthode de la classe

	public Unit(float maxHealth, float speed, float distanceSight, float angleSight, int maxBagSize, float heading) {
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.speed = speed;
		this.distanceSight = distanceSight;
		this.angleSight = angleSight;
		this.maxBagSize = maxBagSize;
		this.currentBagSize = 0;
        this.heading = heading;
        this.bag = new Ressource[maxBagSize];
	}

	public bool isFullBag(){
		return this.currentBagSize == this.maxBagSize;
	}

    public bool isEmptyBag()
    {
        return this.currentBagSize == 0;
    }

    public void take(Ressource r)
    {
        if(!isFullBag())
        {
            this.bag[currentBagSize] = r;
            currentBagSize++;
        }
        else
        {
            Debug.Log("Sac plein");
        }
    }

    public void use(string nameRessource)
    {
        if (!isEmptyBag())
        {
        }
    }

    public void move(Vector3 direction)
    {
        if (!isBlocked())
            unit.transform.position += speed * direction.normalized * 0.2f;
        else
            unit.transform.position *= 1;//Faire quelque chose
    }
    
    public bool isBlocked()
    {
        return true; // A faire
    }

    public float Heading
    {
        get { return this.heading; }
        set { this.heading = value; }
    }


}
