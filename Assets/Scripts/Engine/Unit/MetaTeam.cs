using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaTeam
{
	public string name;
	public Dictionary<string, MetaBrain> brains;
    public ArrayList unitsList;

	public MetaTeam(string n, string fileName){
		name = n;
        brains = new Dictionary<string, MetaBrain>();
        loadXML(fileName);
        unitsList = new ArrayList();
    }

    private void loadXML(string fileName)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(fileName);
        XmlNodeList units = xml.GetElementsByTagName("behavior")[0].ChildNodes;
        foreach(XmlNode unit in units)
        {
            ArrayList tmp = new ArrayList();
            XmlNodeList instructions = unit.ChildNodes;
			foreach(XmlNode instruction in instructions){
				tmp.Add(manageInstruction(instruction));
			}
			brains.Add(unit.Name, new MetaBrain(tmp));
		}
    }
	
    public MetaInstruction manageInstruction(XmlNode instruction)
    {
        XmlNodeList action = instruction.ChildNodes[0].ChildNodes;
        string param = "", methode = "";
        methode = action[0].InnerText;
        if (action.Count == 2)
        {
            param = action[1].InnerText;
        }
        MetaInstruction inst = new MetaInstruction(methode, param);
        for (int i = action.Count; i < instruction.ChildNodes.Count; i++)
        {
            inst.addCondition(new Condition(instruction.ChildNodes[i].InnerText));
        }

        return inst;
	}
}