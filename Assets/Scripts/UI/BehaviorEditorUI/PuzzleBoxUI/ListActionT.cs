using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListActionT : GraphicComponentsList
{
    public ListActionT(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "ACTT";
    }

    override public void CreateComponentButtons()
    {
    }
}
