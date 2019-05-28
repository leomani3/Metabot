using UnityEngine;

public class WarWall : WarUnit
{
    protected WarWall(MetaTeam team, GameObject go, float maxHealth = 200, float armor = 2.0f)
        : base(team, 0, go, maxHealth, 0, 0, 0, armor)
    {
    }
}