using UnityEngine;

public class WarLightScript : MovableUnitScript
{
    void Start()
    {
        unit = new WarLight(gameObject.GetComponentInParent<TeamScript>().Team, gameObject);
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.GetComponent<Collider>().bounds.center.y - gameObject.GetComponent<Collider>().bounds.min.y - gameObject.GetComponent<Collider>().bounds.center.y, gameObject.transform.position.z);
        
    }
}
