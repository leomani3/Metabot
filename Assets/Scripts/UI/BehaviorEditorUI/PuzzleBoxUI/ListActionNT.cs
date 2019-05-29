using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListActionNT : GraphicComponentsList
{
    public ListActionNT(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "ACTNT";
    }

    override public void CreateComponentButtons()
    {
    }
}
