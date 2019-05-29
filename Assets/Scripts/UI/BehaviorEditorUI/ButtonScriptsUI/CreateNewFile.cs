using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewFile : MonoBehaviour
{
    public Dropdown dropDown;
    public InputField inputField;
    private InputField input;

    public void OnClick()
    {
        Debug.Log("Clicked the new file");
        input = Instantiate(inputField, inputField.transform.parent).GetComponent<InputField>();
        input.gameObject.SetActive(true);

        Debug.Log("Instantiated");

        input.onEndEdit.AddListener(delegate { CreateFile(input); });

        
        //Debug.Log("Destroyed");
    }

    private void CreateFile(InputField input)
    {
        string name = input.text;
        Debug.Log("Adding new file");
        this.dropDown.options.Add(new Dropdown.OptionData(name));
        Destroy(input.gameObject);
    }
}
