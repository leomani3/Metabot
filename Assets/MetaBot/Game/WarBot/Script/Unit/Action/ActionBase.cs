﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : ActionCommon
{

    void Start()
    {
        InitAction();
    }

    public override void InitAction()
    {
        base.InitAction(); // IMPORTANT : Permet de recuperer les percepts de la classe mere
        _actions["ACTION_CREATE_LIGHT"] = delegate () {
            Objet o = GetComponent<Inventory>().find("Ressource");
            print("OK");
            GetComponent<Inventory>()._objets[o] -= 10;
            GetComponent<CreatorUnit>().Create("Light");
        };
        _actions["ACTION_CREATE_HEAVY"] = delegate () {
            Objet o = GetComponent<Inventory>().find("Ressource");
            GetComponent<Inventory>()._objets[o] -= 25;
            GetComponent<CreatorUnit>().Create("Heavy");
        };
        _actions["ACTION_BACK_TO_BASE"] = delegate () {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Unit"))
            {
                if (go.GetComponent<Stats>()._unitType == "Base" && go.GetComponent<Stats>()._teamIndex == GetComponent<Stats>()._teamIndex)
                {
                    float a = Utility.getAngle(gameObject, go);
                    GetComponent<Stats>()._heading = a;
                    GetComponent<MovableCharacter>().Move();
                    break;
                }
            }
        };
    }
}
