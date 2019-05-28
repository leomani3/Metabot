using UnityEngine;

public class WarLightScript : MovableUnitScript
{
    void Start()
    {
        unit = new WarLight(gameObject.GetComponentInParent<TeamScript>().Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.GetComponent<Collider>().bounds.center.y - gameObject.GetComponent<Collider>().bounds.min.y - gameObject.GetComponent<Collider>().bounds.center.y, gameObject.transform.position.z);
        
        Color color = Color.white;
        switch (unit.Team.teamName.ToLower())
        {
            case "red":
                //TODO : à la place de changer la couleur il faut load le bon asset
                color = Color.red;
                break;
            case "blue":
                color = Color.blue;
                break;
        }

        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarLight)unit).Heading, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}
