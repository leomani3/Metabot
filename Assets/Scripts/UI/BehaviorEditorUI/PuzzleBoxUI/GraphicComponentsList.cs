using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GraphicComponentsList
{
    protected List<GameObject> buttons;
    protected List<string> buttonNames;
    protected GameObject baseButton;
    protected string type;

    public GraphicComponentsList(GameObject basePrefab)
    {
        this.buttons = new List<GameObject>();
        this.buttonNames = new List<string>();
        this.baseButton = basePrefab;
        this.type = "";
    }

    // Create the buttons depending on the list
    public abstract void CreateComponentButtons();

    // Get the list of labels for the buttons
    //public abstract void GetComponentButtonNames();
}
