using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaTeam
{
	public string teamName;
	public Dictionary<string, MetaBrain> brains;
    public ArrayList unitsList;
    public string teamColor;

	public MetaTeam(string fileName, string name, string color)
    {
        teamColor = color;
        teamName = name;
        brains = new Dictionary<string, MetaBrain>();
        loadXML(fileName);
        unitsList = new ArrayList();
    }

    private void loadXML(string fileName){

		XmlDocument doc = new XmlDocument();
		doc.Load(fileName);

		Dictionary<string, MetaProcedure> lprocs = new Dictionary<string, MetaProcedure>();
		XmlNode behavior = doc.GetElementsByTagName("behavior")[0];

		/** Gestion des procédures **/
		//On récupère les procédures en 1er car important pour la suite
		XmlNode procedures = doc.GetElementsByTagName("procedures")[0];
		if (procedures != null) {
			behavior.RemoveChild(procedures); //On retire des enfants de behavior ce noeud --> pour parcourir les unités plus simplement

			foreach (XmlNode proc in procedures.ChildNodes)
				lprocs.Add(proc.Attributes[0].Value, manageProcedure(proc));
		}

		/** Gestion des unités **/
		XmlNodeList units = behavior.ChildNodes;
		foreach (XmlNode unit in units) {
			List<MetaComportement> tmp = new List<MetaComportement>();
			XmlNodeList instructions = unit.ChildNodes;
			foreach (XmlNode instruction in instructions) {
				tmp.Add(manageComportement(instruction, lprocs));
			}
			brains.Add(unit.Name, new MetaBrain(tmp));
		}

	}

	public MetaProcedure manageProcedure(XmlNode proc){
		List<MetaComportement> lcomp = new List<MetaComportement>(proc.ChildNodes.Count);
		foreach (XmlNode child in proc.ChildNodes) {
			lcomp.Add(manageInstruction(child));
		}
		return new MetaProcedure(proc.Attributes[0].Value, lcomp);
	}

	public MetaComportement manageComportement(XmlNode comportement, Dictionary<string, MetaProcedure> lcomp){
		if (comportement.Name.CompareTo("proc") == 0)
			return lcomp[comportement.Attributes[0].Value];

		return manageInstruction(comportement);
	}

	public MetaInstruction manageInstruction(XmlNode instruction){
        XmlNodeList action = instruction.ChildNodes[0].ChildNodes;

        string param = "", methode = "";
        methode = action[0].InnerText;
        if (action.Count == 2){
            param = action[1].InnerText;
        }

        MetaInstruction inst = new MetaInstruction(methode, param);
        for (int i = 1; i < instruction.ChildNodes.Count; i++){
            inst.addCondition(new Condition(instruction.ChildNodes[i].InnerText));
        }

        return inst;
	}
}