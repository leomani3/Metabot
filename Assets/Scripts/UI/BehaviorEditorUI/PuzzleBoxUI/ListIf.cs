using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListIf : GraphicComponentsList
{
    public ListIf(GameObject basePrefab) : base(basePrefab)
    {
        this.type = "IF";
        CreateComponentButtons();
    }


    override public void CreateComponentButtons()
    {
        //TODO : replace the following line with a function from the interpreter
        this.buttonNames.Add("IF");

        foreach(string but in buttonNames)
        {
            /*Debug.Log("Setting text");
            TextMeshPro name = this.baseButton.GetComponent<TextMeshPro>();
            Debug.Log("Text element found + ");
            if(name == null) Debug.Log("Name not found");
            name.text = "IF";
            Debug.Log("baseButton text set : ");*/
            Transform t = GameObject.Find("ComponentButtons").transform;
            GameObject newButton = GameObject.Instantiate(this.baseButton,t) as GameObject;
            newButton.transform.parent = t;
            //newButton.transform.Translate(new Vector3(0, 800, 0));
            Debug.Log("Instantiated");
            this.buttons.Add(newButton);
        }
    }

}
