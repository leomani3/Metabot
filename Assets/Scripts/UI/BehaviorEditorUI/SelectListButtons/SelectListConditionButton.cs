using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectListConditionButton : SelectListButton
{
    override public void GenerateComponentButtons()
    {
        destroyButtons();

        colour = gameObject.GetComponent<Image>().color;

        remplissageLists();

        for (int i = 0; i < this.listConditions.Count; i++)
        {
            GameObject button = Instantiate(componentButtonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ComponentButton>().SetText(listConditions[i]);

            button.transform.SetParent(componentButtonTemplate.transform.parent, false);

            button.GetComponent<Image>().color = this.colour;

            ComponentButton bComponent = button.GetComponent<ComponentButton>();
            bComponent.setType("COND");
        }
    }
}
