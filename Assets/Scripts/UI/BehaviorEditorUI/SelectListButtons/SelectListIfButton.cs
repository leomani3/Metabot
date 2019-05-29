using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectListIfButton : SelectListButton
{
    /*ListIf list;
    // To be defined in the editor
    public GameObject baseButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting select list if button");
        this.list = new ListIf(baseButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    override public void GenerateComponentButtons()
    {
        destroyButtons();

        colour = gameObject.GetComponent<Image>().color;

        GameObject button = Instantiate(componentButtonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<ComponentButton>().SetText("If");

        button.transform.SetParent(componentButtonTemplate.transform.parent, false);

        button.GetComponent<Image>().color = this.colour;

        ComponentButton bComponent = button.GetComponent<ComponentButton>();
        bComponent.setType("CONT");
    }
}
