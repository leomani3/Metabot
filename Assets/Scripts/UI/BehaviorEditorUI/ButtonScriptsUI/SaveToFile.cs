using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SaveToFile : MonoBehaviour
{
    private string teamName;
    private string unitName;
    private BlockInstruction[] blockInstructions;
    XmlDocument xmlDocument;
    XmlNode rootNode;

    public void OnClick()
    {
        FindTeamName();
        FindUnitName();
        FindInstructions();

        Debug.Log("Team name " + teamName);
        Debug.Log("Unit name " + unitName);
        Debug.Log("Nb instructions " + blockInstructions.Length);

        WriteXML();
        Debug.Log("Saving Done");
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

        if(File.Exists(Application.streamingAssetsPath + "/teams/TestBot/" + teamName + ".wbt"))
        {
            this.xmlDocument.Load(Application.streamingAssetsPath + "/teams/TestBot/" + teamName + ".wbt");
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
        

        xmlDocument.Save(Application.streamingAssetsPath + "/teams/TestBot/" + teamName + ".wbt");
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
        Debug.Log(action.GetName());
        methodNode.InnerText = action.GetName();
        actionNode.AppendChild(methodNode);
        return actionNode;
    }

    private XmlNode CreateConditionNode(ConditionG condition)
    {
        XmlNode condNode = this.xmlDocument.CreateElement("condition");
        Debug.Log(condition.GetName());
        condNode.InnerText = condition.GetName();
        return condNode;
    }

    

}
