﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

[ExecuteInEditMode()]
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public string _gameName;
    public int _minNumberOfTeam;
    public int _maxNumberOfTeam;

    [Header("Units")]
    public List<GameObject> _listUnitGameObject;

    [Header("Debug")]
    public List<string> fileUnit = new List<string>();

    public void Start()
    {
        string gamepath = "./teams/" + _gameName + "/";
        if (!Directory.Exists(gamepath))
        {
            //if it doesn't, create it
            Directory.CreateDirectory(gamepath);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }






    public void SaveGameFile()
    {
        string path = "Assets/MetaBot/Game/WarBot/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);



        foreach (GameObject unit in _listUnitGameObject)
        {
            writer.WriteLine("<");
            writer.WriteLine(unit.GetComponent<Stats>()._unitType);

            // Recuperer les percepts
            writer.WriteLine("[PERCEPTS]");
            Percept unitPercepts = unit.GetComponent<Percept>();
            unitPercepts.InitPercept();
            foreach (string s in unitPercepts._percepts.Keys) { writer.WriteLine(s); }

            // Recuperer les actions
            writer.WriteLine("[ACTIONS]");
            Action unitAction = unit.GetComponent<Action>();
            unitAction.InitAction();
            foreach (string s in unitAction._actions.Keys) {  writer.WriteLine(s); }

            writer.WriteLine(">");
        }

        writer.Close();

        print("Done !");
    }

    public void ReadGameFile()
    {
        string path = "Assets/MetaBot/Game/WarBot/test.txt";
        StreamReader reader = new StreamReader(path);
        string mode = "";

        while ( !reader.EndOfStream )
        {
            string currentString = reader.ReadLine();
            if (currentString.Equals("<"))
            {

            }
        }
        reader.Close();
    }
}
