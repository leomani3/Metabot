using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCondition : GraphicComponentsList
{
    public ListCondition(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "COND";
    }

    override public void CreateComponentButtons()
    {
    }
}
