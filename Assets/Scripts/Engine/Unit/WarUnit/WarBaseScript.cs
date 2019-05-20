using UnityEngine;
using System.Collections;

public class WarBaseScript : UnitScript
{
    void Start()
    {
    }

    //On créer la base de cette méthode car il lui faut la team en param (car c'est le première unité créée)
    public void Instanciate(MetaTeam team)//MAL ECRIT MAIS CONFLIT AVEC Instantiate DE Unity?
    {
        unit = new WarBase(team)
        {
            Unit_go = gameObject
        };
        gameObject.transform.Rotate(Quaternion.Euler(0, 0, 0).eulerAngles);
        foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
