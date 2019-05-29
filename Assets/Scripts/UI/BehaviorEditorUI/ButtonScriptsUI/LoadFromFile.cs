using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using System.IO;

public class LoadFromFile : MonoBehaviour
{
    private string teamName;
    private string unitName;
    private BlockInstruction[] blockInstructions;
    XmlDocument xmlDocument;
    GameObject mainS;

    public GameObject procedurePuzzlePiece;
    public GameObject controlPuzzlePiece;
    public GameObject conditionPuzzlePiece;
    public GameObject messagePuzzlePiece;
    public GameObject actionNTPuzzlePiece;
    public GameObject actionPuzzlePiece;

    public GameObject procedureColour;
    public GameObject controlColour;
    public GameObject conditionColour;
    public GameObject messageColour;
    public GameObject actionNTColour;
    public GameObject actionColour;

    public void Start()
    {
        mainS = GameObject.FindGameObjectWithTag("StartPuzzle");
        OnClick();
    }

    public void OnClick()
    {
        FindTeamName();
        FindUnitName();
        FindInstructions();
        LoadXML();
    }

    private void FindInstructions()
    {
        this.blockInstructions = GameObject.FindObjectsOfType<BlockInstruction>();
    }

    private void FindTeamName()
    {
        GameObject dropdownMenuTeam;
        dropdownMenuTeam = GameObject.FindWithTag("TeamChoiceList");
        int menuIndexTeam = dropdownMenuTeam.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptionsTeam = dropdownMenuTeam.GetComponent<Dropdown>().options;
        teamName = menuOptionsTeam[menuIndexTeam].text;
    }

    private void FindUnitName()
    {
        GameObject dropdownMenuUnit;
        dropdownMenuUnit = GameObject.FindWithTag("UnitChoiceList");
        int menuIndex = dropdownMenuUnit.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = dropdownMenuUnit.GetComponent<Dropdown>().options;
        unitName = menuOptions[menuIndex].text;
    }

    private void LoadXML()
    {
        // Remove everything currently on the screen
        foreach (BlockInstruction b in blockInstructions)
        {
            Debug.Log("Trying to delete");
            b.Delete();
            Debug.Log("Deleted");
        }

        if (File.Exists(Application.dataPath + "/StreamingAssets/teams/TestBot/" + teamName + ".wbt"))
        {
            LoadInstructionBlocks();
        }
        else Debug.Log("File does not exist");

        Debug.Log("Load file done");
            
    }

    private void LoadInstructionBlocks()
    {
        this.xmlDocument = new XmlDocument();
        this.xmlDocument.Load(Application.dataPath + "/StreamingAssets/teams/TestBot/" + teamName + ".wbt");

        XmlNode rootNode = this.xmlDocument.DocumentElement;
        XmlNodeList nodeUnits = rootNode.SelectNodes(unitName);

        Debug.Log("Trying to load");

        if (nodeUnits.Count == 0)
        {
            Debug.Log("Nothing to load");
            return;
        }
        else
        {
            XmlNode nodeUnit = nodeUnits[0];

            XmlNodeList nodeInstruction = nodeUnit.SelectNodes("instruction");

            int id = 0;

            foreach (XmlNode nodeInstr in nodeInstruction)
            {
                BlockInstruction cp = CreateControlPuzzlePiece();
                //cp.transform.localPosition = new Vector2(100, 100);
                float yPos = -cp.GetComponent<BoxCollider2D>().size.y * id;
                cp.transform.localPosition = new Vector3(0, yPos, 0);
                //cp.init();
                id++;

                XmlNodeList nodeActions = nodeInstr.SelectNodes("action/methode");
                XmlNodeList nodeConditions = nodeInstr.SelectNodes("condition");

                int idA = 0;
                foreach (XmlNode nodeAct in nodeActions)
                {
                    GraphicComponent cpA = CreatePuzzlePiece(this.actionPuzzlePiece, this.actionColour, nodeAct.InnerText);
                    cpA.transform.localPosition = cpA.transform.localPosition + new Vector3(75 + 150 * idA, -112.5f - 150 * (id - 1), 0);
                    ActionTG action = cpA.GetComponent<ActionTG>();
                    cp.SetActionTG(action);
                    idA++;
                }

                int idC = 0;
                foreach (XmlNode nodeCond in nodeConditions)
                {
                    GraphicComponent cpC = CreatePuzzlePiece(this.conditionPuzzlePiece, this.conditionColour, nodeCond.InnerText);
                    cpC.transform.localPosition = cpC.transform.localPosition + new Vector3(75 + 150 * idC, 112.5f - 150 * id, 0);
                    //cpC.AddToBlockInstruction();
                    ConditionG cond = cpC.GetComponent<ConditionG>();
                    cp.AddConditionG(cond);
                    idC++;
                }
            }
        }  
    }

    private GraphicComponent CreatePuzzlePiece(GameObject pieceTemplate, GameObject colourPiece, string label)
    {
        GameObject createdPiece = Instantiate(pieceTemplate);

        Color colour = colourPiece.GetComponent<Image>().color;
        createdPiece.GetComponent<Image>().color = colour;

        Text textfield = createdPiece.GetComponentInChildren(typeof(Text)) as Text;
        textfield.text = label;

        createdPiece.transform.SetParent(pieceTemplate.transform.parent, false);
        createdPiece.SetActive(true);

        return createdPiece.GetComponent<GraphicComponent>();
    }

    private BlockInstruction CreateControlPuzzlePiece()
    {
        GameObject createdPiece = Instantiate(this.controlPuzzlePiece);

        Color colour = this.controlColour.GetComponent<Image>().color;
        createdPiece.GetComponent<Image>().color = colour;

        Text textfield = createdPiece.GetComponentInChildren(typeof(Text)) as Text;
        textfield.text = "If";

        createdPiece.transform.SetParent(this.controlPuzzlePiece.transform.parent, false);
        createdPiece.SetActive(true);

        return createdPiece.GetComponent<BlockInstruction>();
    }
}
