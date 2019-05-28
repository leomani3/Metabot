﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : Feature
{
    protected readonly float speed;
    private string Target { get; set; }
    private float MAX_DISTANCE_TAKE_GIVE = 10.0f;

    public Movable(Unit unit, float speed) : base(unit)
    {
        this.speed = speed;
    }

    public void Move()
    {
        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

    public void Take()
    {
        GameObject nearestRessources = unit.GetNearestRessource();
        if (nearestRessources != null && !unit.IsFullBag())
        {
            if (Vector3.Distance(unit.Unit_go.transform.position, nearestRessources.transform.position) <= MAX_DISTANCE_TAKE_GIVE)
            {
                unit.Bag.Add(nearestRessources.GetComponent<ResourcesScript>().Ressource);
                unit.CurrentBagSize += 1;
                unit.RessourcesInSight.Remove(nearestRessources);
                Object.Destroy(nearestRessources);
            }
            else
            {
                float angle = Utility.getAngle(unit.Unit_go.transform.position, nearestRessources.transform.position);
                unit.Heading = angle;
                Move();
            }
        }
    }

    public void Give()
    {
        GameObject nearestAllie = unit.GetNearestAllies();//A changer par allié qui a le moins de vie 
        if (nearestAllie != null && !unit.IsEmptyBag() && !nearestAllie.GetComponent<UnitScript>().Unit.IsFullBag())
        {
            if(Vector3.Distance(unit.Unit_go.transform.position, nearestAllie.transform.position) < MAX_DISTANCE_TAKE_GIVE)
            {
                nearestAllie.GetComponent<UnitScript>().Unit.Bag.Add(unit.Bag[0]);
                nearestAllie.GetComponent<UnitScript>().Unit.CurrentBagSize += 1;
                unit.Bag.RemoveAt(0);
                unit.CurrentBagSize -= 1;
            }
            else
            {
                float angle = Utility.getAngle(unit.Unit_go.transform.position, nearestAllie.transform.position);
                unit.Heading = angle;
                Move();
            }
        }
    }

    public void MoveTo()
    {
        GameObject go_target = null;
        switch (Target)
        {
            case "allie":
                go_target = unit.GetNearestAllies();
                break;
            case "enemie":
                go_target = unit.GetNearestEnemy(); 
                break;
            case "resource":
                go_target = unit.GetNearestRessource();
                break;
            case "base": //Base alliée
                break;
            case "baseEnemie": //Base enemie la plus proche (plusieurs base à 4 joueur)
                break;
        }
        if(go_target != null)
        {
            float angle = Utility.getAngle(unit.Unit_go.transform.position, unit.GetNearestEnemy().transform.position);
            unit.Heading = angle;
        }

        unit.Unit_go.transform.position += speed * Utility.vectorFromAngle(unit.Heading).normalized * 0.1f; //*0.2f normalement
    }

}
