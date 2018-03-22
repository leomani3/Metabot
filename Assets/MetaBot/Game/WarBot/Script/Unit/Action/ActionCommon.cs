﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCommon : Action
{

    void Start()
    {
        InitAction();
    }

    public override void InitAction()
    {
        _actions["ACTION_IDLE"] = delegate () { };
        _actions["ACTION_GIVE_RESSOURCE"] = delegate ()
        {
            GameObject target = GetComponent<Stats>()._target;
            if (target != null)
            {
                Objet item = GetComponent<Inventory>().find("Ressource");
                if (GetComponent<Inventory>()._objets.ContainsKey(item) && GetComponent<Inventory>()._objets[item] != 0 && target.GetComponent<Inventory>())
                {
                    if (Vector3.Distance(GetComponent<Stats>()._target.transform.position, transform.position) < 1.75f)
                    {
                        target.GetComponent<Inventory>().add(item);
                        GetComponent<Inventory>().pop(item);
                    }
                }
            }
        };
        _actions["ACTION_HEAL"] = delegate () { GetComponent<Inventory>().use("Ressource"); };
    }


}