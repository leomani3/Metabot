using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectListButton : MonoBehaviour
{
    public GameObject componentButtonTemplate;
    protected Color colour;

    protected void destroyButtons()
    {

        GameObject[] existingControles = GameObject.FindGameObjectsWithTag("ComponentButton");

        foreach(GameObject button in existingControles)
        {
            Destroy(button.gameObject);
        }
    }

    public abstract void GenerateComponentButtons();
}
