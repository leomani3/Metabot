using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectListProcButton : SelectListButton
{
    //Color colour;

    override public void GenerateComponentButtons()
    {
        destroyButtons();
        colour = gameObject.GetComponent<Image>().color;

        for (int i = 0; i < this.listProcedures.Count; i++)
        {
            Generate(listProcedures[i]);
        }
    }

    private void Generate(string name)
    {
        GameObject button = Instantiate(componentButtonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<ComponentButton>().SetText(name);

        button.transform.SetParent(componentButtonTemplate.transform.parent, false);

        button.GetComponent<Image>().color = this.colour;

        ComponentButton bComponent = button.GetComponent<ComponentButton>();
        bComponent.setType("PROC");
    }
}
