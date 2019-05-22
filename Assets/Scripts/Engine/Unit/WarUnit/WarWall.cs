public class WarWall : WarUnit
{
    protected WarWall(MetaTeam team, float maxHealth = 200, float armor = 2.0f)
        : base(team, 0, maxHealth, 0, 0, 0, armor)
    {
    }
}