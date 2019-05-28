using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Ressource
{
    private float heal = 25.0f;
    public Food(GameObject go, string name = "Food", int weight = 1) : base(name, weight,go)
    {
    }

    public override void UseRessource(Unit unit)
    {
        unit.CurrentHealth += heal;
    }
}
