using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMessage : GraphicComponentsList
{
    public ListMessage(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "MESS";
    }

    override public void CreateComponentButtons()
    {
    }
}
