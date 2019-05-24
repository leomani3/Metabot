using UnityEngine;
using System.Collections;

public class WarBaseScript : UnitScript
{
    void Start()
    {
        unit = new WarBase(gameObject.gameObject.transform.parent.GetComponent<TeamScript>().Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, 0, 0).eulerAngles);

        Color color = Color.white;
        switch (unit.Team.name)
        {
            case "Red":
                color = Color.red;
                break;
            case "Blue":
                color = Color.blue;
                break;
        }

        //TODO : voir si'l faut pas lui donner une orientation aléatoire au début
        //gameObject.transform.Rotate(Quaternion.Euler(0, ((WarBase)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}
