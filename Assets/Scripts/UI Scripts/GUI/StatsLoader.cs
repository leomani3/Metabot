﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class StatsLoader : MonoBehaviour
{

    public Dropdown unit;

    public void Start()
    {
        ReadStats();
    }

    public void ReadStats()
    {
        Text statText = GameObject.Find("PropertiesValues").GetComponentInChildren<Text>();
        Image imageUnit = GameObject.Find("ImageUnit").GetComponent<Image>();
        Image heavySprite = GameObject.Find("HeavySprite").GetComponent<Image>();
        Image baseSprite = GameObject.Find("BaseSprite").GetComponent<Image>();
        Image lightSprite = GameObject.Find("LightSprite").GetComponent<Image>();
        Image explorerSprite = GameObject.Find("ExplorerSprite").GetComponent<Image>();

        string unitName = unit.captionText.text;
        int statBase = 4;
        int statExplo = 5;
        int statHeavy = 6;
        string fileName = "properties.yml";
        TextReader reader;
        reader = new StreamReader(fileName);
        string line;
        while (true)
        {
            // lecture de la ligne
            line = reader.ReadLine();

            // si la ligne est vide on arrête
            if (line == null) break;

            // Lecture des statistiques de la base
            else if (unitName == "Base" && line.Contains("WarBase"))
            {
                readStatsFile(unitName, reader, statBase, statText);
                imageUnit.sprite = baseSprite.sprite;
                imageUnit.color = new Color(imageUnit.color.r, imageUnit.color.g, imageUnit.color.b, 255);
                /*
                for(int i = 0; i < statBase; i++)
                {
                    line = reader.ReadLine();
                    // on affiche la ligne
                    //Debug.Log("VALUE LINE = " + line);
                    if (i == 0)
                    {
                        string oldTexte = statText.text;
                        //Debug.Log("VALEUR OLDTEEEEEEEEEEEEXTEEEEEE ====== " + oldTexte);
                        //statText.text.Replace(oldTexte, line);
                        statText.text = line;
                    }
                    else
                    {
                        string oldText = statText.text;
                        string newText = oldText + line;
                        Debug.Log("VALEUR OLDTEEEEEEEEEEEEXT ====== " + oldText);
                        Debug.Log("VALEUR NEEEEEEEEEW ====== " + newText);
                        statText.text = newText;
                    }
                }*/
            }

            // Lecture des statistiques des explorateurs

            else if (unitName == "Explorer" && line.Contains("WarExplorer"))
            {
                readStatsFile(unitName, reader, statExplo, statText);
                imageUnit.sprite = explorerSprite.sprite;
                imageUnit.color = new Color(imageUnit.color.r, imageUnit.color.g, imageUnit.color.b, 255);
            }

            else if (unitName == "Heavy" && line.Contains("WarHeavy"))
            {
                readStatsFile(unitName, reader, statHeavy, statText);
                imageUnit.sprite = heavySprite.sprite;
                imageUnit.color = new Color(imageUnit.color.r, imageUnit.color.g, imageUnit.color.b, 255);
            }

            else if (unitName == "Light")
            {
                statText.text = "No data available";
                imageUnit.sprite = lightSprite.sprite;
                imageUnit.color = new Color(imageUnit.color.r, imageUnit.color.g, imageUnit.color.b, 255);
            }


        }
        reader.Close();
    }


    void readStatsFile(string unitName, TextReader reader, int nbrStats, Text statText)
    {
        string langage = "";
        string[] lines = System.IO.File.ReadAllLines("properties.yml");
        foreach (string line1 in lines)
        {
            if (line1.Contains("Language"))
            {
                string[] tmp = line1.Split('=');
                langage = tmp[1];
                break;
            }
        }

        string line;

        for (int i = 0; i < nbrStats; i++)
        {
            line = reader.ReadLine();
            if (i == 0)
            {
                string oldText = statText.text;
                line = line.Replace("   ", "").Replace(" ","");
                string[] splited = line.Split(':');
                string trad = splited[0];
                if (GameObject.Find("GameManager"))
                {
                    GameObject.Find("GameManager").GetComponent<Traducteur>().setTextOriginal(splited[0]);
                    trad = GameObject.Find("GameManager").GetComponent<Traducteur>().traduction;
                }
                line = "    "+trad + ": " + splited[1];
                statText.text = line;
            }
            else
            {
                string oldText = statText.text;
                line = line.Replace("   ", "").Replace(" ","") ;
                string[] splited = line.Split(':');
                string trad = splited[0];
                if (GameObject.Find("GameManager"))
                {
                    GameObject.Find("GameManager").GetComponent<Traducteur>().setTextOriginal(splited[0]);
                    trad = GameObject.Find("GameManager").GetComponent<Traducteur>().traduction;
                }
                line = "    "+trad + ": " + splited[1];
                string newText = oldText + line;
                statText.text = newText;
                statText.resizeTextForBestFit = true;
            }
        }
    }
}