﻿using System.Collections.Generic;
using UnityEngine;

public class WarBase : WarUnit
{
    private Creator creatorFeature;

    public WarBase(MetaTeam team,
        float maxHealth = 300, float distanceSight = 20.0f, float angleSight = 180.0f,
        int maxBagSize = 10, float armor = 1.0f)
        : base(team, 0, maxHealth, distanceSight, angleSight, maxBagSize, armor)
    {
        //On créé l'AgentList qui contient tous les type d'unité que je peux créer
        List<System.Type> al = new List<System.Type>();
        al.Add(typeof(WarLight));
        al.Add(typeof(WarEngineer));
        creatorFeature = new Creator(this, al);    //permet à l'unite de pouvoir créer d'autre unités. Il faut lui passer une AL en paramètres.
    }

    public void Create()
    {
        creatorFeature.Type = typeof(WarLight); //TODO : cette ligne à était mise pour les tests
        creatorFeature.Create();
    }

    public Creator CreatorFeature
    {
        get { return creatorFeature; }
    }

    public override float Heading
    {
        get
        {
            return heading;
        }

        set
        {
            heading = value;
        }
    }
}
