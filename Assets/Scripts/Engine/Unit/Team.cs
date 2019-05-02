using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

public class MetaTeam
{
	public string name;
	public Dictionary<string, MetaBrain> brains;

	public MetaTeam(string n, string fileName){
		name = n;
		loadXML(fileName);
	}
   
	private void loadXML(string fileName)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(fileName);
        XmlNodeList units = xml.GetElementsByTagName("behavior")[0].ChildNodes;
		ArrayList tmp = new ArrayList();
        foreach(XmlNode unit in units){
			tmp.Clear();
			XmlNodeList instructions = unit.ChildNodes;
			foreach(XmlNode instruction in instructions){
				tmp.Add(manageInstruction(instruction));
			}
			brains.Add(typeof(Unit).ToString(), new MetaBrain(tmp));
		}
    }
	
    public MetaInstruction manageInstruction(XmlNode instruction)
    {
        XmlNodeList children = instruction.ChildNodes;
		XmlNode conditions = children[0];
		XmlNode action = children[1];
		string condition = conditions.InnerText;

        string param = instruction.ChildNodes[0].InnerText;
        string methode = instruction.ChildNodes[1].InnerText;
        MetaInstruction inst = new MetaInstruction(param, methode);
        //PARCOURS LES CONDITIONS PUIS AJOUTE DANS inst
        for (int i = 2; i < instruction.ChildNodes.Count; i++)
        {
            inst.addCondition(new Condition(instruction.ChildNodes[i].InnerText));
        }

        return inst;
	}
}