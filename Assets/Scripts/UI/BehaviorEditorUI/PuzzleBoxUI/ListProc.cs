using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListProc : GraphicComponentsList
{
    public ListProc(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "PROC";
    }

    override public void CreateComponentButtons()
    {
    }
}
