using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XmlTranslator : MonoBehaviour
{
    private string teamName;
    private string unitName;
    private BlockInstruction[] blockInstructions;
    XmlDocument xmlDocument;
    XmlNode rootNode;
    private string path;

    Dictionary<string, string> dictionaryAction = new Dictionary<string, string>();
    Dictionary<string, string> dictionaryCondition = new Dictionary<string, string>();

    public void Awake()
    {
        dictionaryAction.Add("Heal", "Heal");
        dictionaryAction.Add("Give", "Give");
        dictionaryAction.Add("Create Light", "Create Light");
        dictionaryAction.Add("Create Heavy", "Create Heavy");
        dictionaryAction.Add("Create Explorer", "Create Explorer");
        dictionaryAction.Add("Move", "Move");
        dictionaryAction.Add("Pick", "Pick");
        dictionaryAction.Add("Random Move", "Random Move TODO");
        dictionaryAction.Add("TurnAround Move", "TurnAround Move TODO");
        dictionaryAction.Add("Back to base", "MoveTo base");
        dictionaryAction.Add("Back to allies", "Back to allie");
        dictionaryAction.Add("Move to enemy", "Back to enemie");
        dictionaryAction.Add("Shoot", "Shoot");

        dictionaryCondition.Add("Max health", "currentHealth == maxHealth");
        dictionaryCondition.Add("Health > 75", "currentHealth > 0.75 * maxHealth" );
        dictionaryCondition.Add("Health > 50", "currentHealth > 0.50 * maxHealth" );
        dictionaryCondition.Add("Health > 25", "currentHealth > 0.25 * maxHealth");
        dictionaryCondition.Add("Bag full", "currentBagSize == maxBagSize");
        dictionaryCondition.Add("Bag empty", "currentBagSize == 0");
        dictionaryCondition.Add("Not empty", "currentBagSize > 0");
        dictionaryCondition.Add("Ally near", "alliesCount > 0");
        dictionaryCondition.Add("Enemy near", "enemiesCount > 0");
        dictionaryCondition.Add("Can Give", "Can Give TODO");
        dictionaryCondition.Add("Ally Base near", "nearBaseAllie == 1");
        dictionaryCondition.Add("Ressource near", "ressourceCount > 0");
    }


    public void OnClick()
    {
        FindTeamName();
        FindUnitName();
        FindInstructions();
        this.path = Application.dataPath + "/StreamingAssets/teams/" + teamName + ".wbt";

        WriteXML();
        Debug.Log("Saving Done XML");
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

    private void FindInstructions()
    {
        this.blockInstructions = GameObject.FindObjectsOfType<BlockInstruction>();
    }

    private void WriteXML()
    {
        this.xmlDocument = new XmlDocument();

        if (File.Exists(path))
        {
            this.xmlDocument.Load(path);
            EraseExisting();
        }
        else
        {
            CreateFile();
        }

        CreateUnit();
    }

    private void EraseExisting()
    {
        this.rootNode = this.xmlDocument.DocumentElement;
        XmlNodeList nodeUnits = rootNode.SelectNodes(unitName);
        if (nodeUnits[0] != null)
        {
            nodeUnits[0].RemoveAll();
            this.rootNode.RemoveChild(nodeUnits[0]);
        }
    }

    private void CreateFile()
    {
        this.rootNode = xmlDocument.CreateElement("behavior");
        xmlDocument.AppendChild(rootNode);
    }

    private void CreateUnit()
    {
        XmlNode unitNode = xmlDocument.CreateElement(unitName);
        this.rootNode.AppendChild(unitNode);


        for (int i = this.blockInstructions.Length - 1; i >= 0; i--)
        {
            XmlNode instructionNode = CreateInstructionNode(this.blockInstructions[i]);
            unitNode.AppendChild(instructionNode);
        }


        xmlDocument.Save(path);
    }

    private XmlNode CreateInstructionNode(BlockInstruction b)
    {
        XmlNode instructionNode = this.xmlDocument.CreateElement("instruction");
        ActionTG action = b.GetActionTG();
        if (action != null)
        {
            XmlNode actionNode = CreateActionTNode(action);
            instructionNode.AppendChild(actionNode);
        }

        foreach (ConditionG c in b.GetConditionGs())
        {
            XmlNode condNode = CreateConditionNode(c);
            instructionNode.AppendChild(condNode);
        }

        return instructionNode;
    }

    private XmlNode CreateActionTNode(ActionTG action)
    {
        XmlNode actionNode = this.xmlDocument.CreateElement("action");
        XmlNode methodNode = this.xmlDocument.CreateElement("methode");
        //Debug.Log(action.GetName());
        string name;
        bool found = dictionaryAction.TryGetValue( action.GetName(), out name);
        actionNode.AppendChild(methodNode);
        methodNode.InnerText = name;
        return actionNode;
    }

    private XmlNode CreateConditionNode(ConditionG condition)
    {
        XmlNode condNode = this.xmlDocument.CreateElement("condition");
        //Debug.Log(condition.GetName());
        string name;
        bool found = dictionaryCondition.TryGetValue(condition.GetName(), out name);
        condNode.InnerText = name;
        return condNode;
    }

}
