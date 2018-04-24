﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject[] _DropDownList;
    public GameObject _numberplayerDropDown;
    public Color[] playerColor;
    public int nbPlayers;
    public Dropdown mapChoice;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartGame()
    {
        string s = mapChoice.captionText.text;
        nbPlayers = int.Parse(_numberplayerDropDown.GetComponent<Dropdown>().captionText.text);
        XMLWarbotInterpreter interpreter = new XMLWarbotInterpreter();
        string gamePath = Application.streamingAssetsPath + "/teams/" + GameObject.Find("GameManager").GetComponent<GameManager>()._gameName + "/";
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<TeamManager>()._teams = new List<Team>();

        for (int i = 0; i < nbPlayers; i++)
        {
            Team team = new Team();
            team._color = playerColor[i];
            team._name = _DropDownList[i].GetComponent<Dropdown>().captionText.text.Replace("_", " ");
            team._unitsBehaviour = interpreter.xmlToBehavior(gamePath + team._name, gamePath);
            gameManager.GetComponent<TeamManager>()._teams.Add(team);
        }
        if(s == "Standard")
        {
            SceneManager.LoadScene(1);
        }
        else if(s == "Test")
        {
            SceneManager.LoadScene(3);
        }
        else if (s == "Plaine")
        {
            SceneManager.LoadScene(4);
        }
        //SceneManager.LoadScene(id);
    }
}
