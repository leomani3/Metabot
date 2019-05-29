using UnityEngine;
using System.Collections;

public class WarBaseScript : UnitScript
{
    void Start()
    {
        unit = new WarBase(gameObject.gameObject.transform.parent.GetComponent<TeamScript>().Team, gameObject);
    }
}
