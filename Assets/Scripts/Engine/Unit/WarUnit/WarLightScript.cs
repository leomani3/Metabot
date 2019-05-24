using UnityEngine;

public class WarLightScript : UnitScript
{
    void Start()
    {
        unit = new WarLight(gameObject.GetComponentInParent<TeamScript>().Team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, ((WarLight)unit).Heading, 0).eulerAngles);
        Debug.Log("Size = " + gameObject.GetComponent<Collider>().bounds.size);
        Debug.Log("Min = " + gameObject.GetComponent<Collider>().bounds.min);
        Debug.Log("Center = " + gameObject.GetComponent<Collider>().bounds.center);
        Debug.Log(gameObject.GetComponent<Collider>().bounds.min - gameObject.GetComponent<Collider>().bounds.center);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.GetComponent<Collider>().bounds.center.y - gameObject.GetComponent<Collider>().bounds.min.y - gameObject.GetComponent<Collider>().bounds.center.y, gameObject.transform.position.z);

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

        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = color;
        }
    }
}
