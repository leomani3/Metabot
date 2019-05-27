using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentButton : MonoBehaviour
{
    // public string listType;     // To be set in the interpreter

    private string type;
    public Text label;
    private string labelString;

    public GameObject procedurePuzzlePiece;
    public GameObject controlPuzzlePiece;
    public GameObject conditionPuzzlePiece;
    public GameObject messagePuzzlePiece;
    public GameObject actionNTPuzzlePiece;
    public GameObject actionPuzzlePiece;

    public void SetText(string labelString)
    {
        this.label.text = labelString;
        this.labelString = labelString;
    }

    void Start()
    {
    }

    // Add a piece to the puzzle
    public void OnClick()
    {
        switch (type)
        {
            case "PROC":
                createPuzzlePiece(this.procedurePuzzlePiece);
                Debug.Log("Procedure");
                break;
            case "CONT":
                createPuzzlePiece(this.controlPuzzlePiece);
                Debug.Log("Control");
                break;
            case "COND":
                createPuzzlePiece(this.conditionPuzzlePiece);
                Debug.Log("Condition");
                break;
            case "MESS":
                createPuzzlePiece(this.messagePuzzlePiece);
                Debug.Log("Message");
                break;
            case "ACTNT":
                createPuzzlePiece(this.actionNTPuzzlePiece);
                Debug.Log("Action NT");
                break;
            case "ACTT":
                createPuzzlePiece(this.actionPuzzlePiece);
                Debug.Log("Action");
                break;
            default:
                Debug.Log("Not a legit type");
                break;
        }
        //Debug.Log("Type : " + type);
    }

    public string getType() { return this.type; }
    public void setType(string type) { this.type = type;}

    private void createPuzzlePiece(GameObject pieceTemplate)
    {
        GameObject createdPiece = Instantiate(pieceTemplate);

        Color colour = gameObject.GetComponent<Image>().color;
        createdPiece.GetComponent<Image>().color = colour;

        Text textfield = createdPiece.GetComponentInChildren(typeof(Text)) as Text;
        textfield.text = this.labelString;

        createdPiece.transform.SetParent(pieceTemplate.transform.parent, false);
        createdPiece.SetActive(true);
    }
}
