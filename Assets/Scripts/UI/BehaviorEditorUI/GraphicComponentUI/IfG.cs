using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfG : BlockInstruction
{
    public GameObject ProcModel;
    public GameObject ProcColour;

    public InputField inputField;
    private InputField input;
    private ProcG procBlock;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && currentlySelected.Contains(this))
        {
            input = Instantiate(inputField, inputField.transform.parent).GetComponent<InputField>();
            input.gameObject.SetActive(true);

            input.onEndEdit.AddListener(delegate { CreateProcInstruction(input); });
        }
    }

    private void CreateProcInstruction(InputField input)
    {
        string name = input.text;

        SwitchToProc(name);
        SelectListProcButton[] slb = GameObject.FindObjectsOfType<SelectListProcButton>();
        slb[0].AddToProcedures(name, procBlock);
        Destroy(input.gameObject);
    }

    private void SwitchToProc(string name)
    {
        procBlock = CreateProc(name);
        procBlock.TakeAttributes(this);
        Transform trans = procBlock.gameObject.transform;
        trans.localPosition = this.transform.localPosition;
        this.Delete();
    }

    private ProcG CreateProc(string name)
    {
        GameObject createdPiece = Instantiate(this.ProcModel, this.transform.parent);

        Debug.Log("Created");

        Color colour = ProcColour.gameObject.GetComponent<Image>().color;
        createdPiece.GetComponent<Image>().color = colour;

        Text textfield = createdPiece.GetComponentInChildren(typeof(Text)) as Text;
        textfield.text = name;
        
        createdPiece.SetActive(true);

        return createdPiece.GetComponent<ProcG>();
    }

}
