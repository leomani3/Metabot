﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject[] _DropDownList;
    public Color[] playerColor;
    public int nbPlayers;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartGame()
    {
        XMLWarbotInterpreter interpreter = new XMLWarbotInterpreter();
        string gamePath = "./teams/" + GameObject.Find("GameManager").GetComponent<GameManager>()._gameName + "/";
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<TeamManager>()._teams = new List<Team>();

        for (int i = 0; i < nbPlayers; i++)
        {
            Team team = new Team();
            team._color = playerColor[i];
            team._name = _DropDownList[i].GetComponent<Dropdown>().captionText.text;
            team._unitsBehaviour = interpreter.xmlToBehavior(team._name, gamePath);
            gameManager.GetComponent<TeamManager>()._teams.Add(team);
        }
        SceneManager.LoadScene(1);
    }
}
