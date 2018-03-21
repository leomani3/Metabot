﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;


public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public string _gameName;
    public string gamepath;
    public int _minNumberOfTeam;
    public int _maxNumberOfTeam;

    [Header("Units")]
    public List<GameObject> _listUnitGameObject;

    [Header("Debug")]
    public List<string> fileUnit = new List<string>();

    static bool created = false;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        gamepath = "./teams/" + _gameName + "/";
        if (!Directory.Exists(gamepath))
        {
            //if it doesn't, create it
            Directory.CreateDirectory(gamepath);

        }
    } 






    public void SaveGameFile()
    {
        string path = "Assets/MetaBot/Game/WarBot/" + _gameName + ".gameset";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);



        foreach (GameObject unit in _listUnitGameObject)
        {
            writer.WriteLine("<");
            writer.WriteLine(unit.GetComponent<Stats>()._unitType);

            // Recuperer les percepts
            writer.WriteLine("[PERCEPTS]");
            Percept unitPercepts = unit.GetComponent<Percept>();
            Debug.Log(unit.name + " PERCEPT : "+unitPercepts.name);
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

}
