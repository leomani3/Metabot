using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feature
{
    protected Unit unit;

    protected Feature(Unit user)
    {
        this.unit = user;
    }
}
