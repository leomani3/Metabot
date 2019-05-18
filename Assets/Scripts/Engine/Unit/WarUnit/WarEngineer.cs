using System.Collections.Generic;

public class WarEngineer : MovableUnit
{
    private Creator creatorFeature;

    public WarEngineer(MetaTeam team, float maxHealth = 200, float speed = 1.8f, float distanceSight = 20.0f, float angleSight = 180.0f, int maxBagSize = 5, float heading = 45.0f, float timeReload = 1.0f, float armor = 1.0f) : base(maxHealth, distanceSight, angleSight, maxBagSize, heading, timeReload, armor, team)
    {
        //On créer l'AL qui contient tous les type d'unité que je peux créer
        List<System.Type> al = new List<System.Type>();
        al.Add(typeof(WarLight));
        al.Add(typeof(WarExplorer));
        this.creatorFeature = new Creator(this, al);    //permet à l'unite de pouvoir créer d'autre unités. Il faut lui passer une AL en paramètres.
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
