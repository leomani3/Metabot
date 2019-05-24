using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigLoader : MonoBehaviour {
    public List<UnitConfig> configuration;

	// Use this for initialization
	void Start () {
        configuration = new List<UnitConfig>();
        getAllStats();
    }

    void getAllStats()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/proprietes.cfg");
        int cpt = 0;
        foreach (string line in lines)
        {
            cpt++;
            if (line.Contains("Unit"))
            {
                int stats = cpt;
                string line2 = line.Replace("\t", "");
                string[] tmp = line2.Split(':');
                UnitConfig u = new UnitConfig();
                u.unit = tmp[1];
                u.stats = new List<Stat>();
                //stats++;
                while (!lines[stats].Contains(";"))
                {
                    Stat s = new Stat();
                    string lign2 = lines[stats].Replace("\t", "");
                    string[] lignetmp = lign2.Split(':');
                    s.cle = lignetmp[0];
                    s.valeur = float.Parse(lignetmp[1]);
                    u.stats.Add(s);
                    stats++;
                }
                configuration.Add(u);
            }
        }
    }	
}

[System.Serializable]
public struct UnitConfig
{
    public string unit;
    public List<Stat> stats;
}

[System.Serializable]
public struct Stat
{
    public string cle;
    public float valeur;
}