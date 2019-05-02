using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    protected Unit unit;
    protected Team team;
    protected Brain brain;

    /*
     * TODO :
     * -l'attribut "team" fait référence à l'équipe de l'Unit -> rajouter ça dans le constructeur
     * -Dans l'update il faudra appeler brain.decide(this)
     * */

    public Unit Unit
    {
        get { return unit; }
    }

    void OnCollisionStay(Collision other)
    {
        unit.OnCollisionStay(other);
    }

    void Update()
    {
        
    }
}
