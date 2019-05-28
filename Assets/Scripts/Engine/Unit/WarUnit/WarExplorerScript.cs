using UnityEngine;

public class WarExplorerScript : MovableUnitScript
{
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<TeamScript>().Team, gameObject);
    }
}
