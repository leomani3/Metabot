using UnityEngine;

public class WarExplorerScript : UnitScript
{
    void Start()
    {
        unit = new WarExplorer(gameObject.GetComponentInParent<TeamScript>().Team, gameObject);
    }
}
