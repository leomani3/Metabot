using System.Collections.Generic;

public class WarBase : WarUnit
{
    private Creator creatorFeature;

    protected WarBase(MetaTeam team,
        float maxHealth = 200, float distanceSight = 20.0f, float angleSight = 180.0f,
        int maxBagSize = 10, float armor = 1.0f)
        : base(team, maxHealth, distanceSight, angleSight, maxBagSize, armor)
    {
        //On créé l'AgentList qui contient tous les type d'unité que je peux créer
        List<System.Type> al = new List<System.Type>();
        al.Add(typeof(WarLight));
        al.Add(typeof(WarEngineer));
        creatorFeature = new Creator(this, al);    //permet à l'unite de pouvoir créer d'autre unités. Il faut lui passer une AL en paramètres.
    }

    public void Create()
    {
        creatorFeature.Create();
    }

    public Creator CreatorFeature
    {
        get { return creatorFeature; }
    }
}
