﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

    public delegate bool Tests();
    public delegate void Ends();
    public Dictionary<string, Tests> _tests = new Dictionary<string, Tests>();
    public Dictionary<string, Ends> _ends = new Dictionary<string, Ends>();
    public string _gamename;
    public int winner;
    public string winnername;
    Animator anim;
    public GameObject textWinnerTeam;
    public bool written;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        InitTests();
        InitEnds();
        winner = -1;
        _gamename = GameObject.FindObjectOfType<GameManager>()._gameName;
        written = false;
        winnername = "";
	}

    public void InitEnds()
    {
        _ends["TestBot"] = delegate ()
        {
            textWinnerTeam.GetComponent<Text>().text = "Winner : " + winnername;
            print("after Winnerteam");
            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            foreach (GameObject u in units)
            {
                Destroy(u);
            }
            anim.SetTrigger("GameOver");
            print("after TextGO");
            if (!written)
            {
                TeamsPerformance p = new TeamsPerformance();
                int size = GameObject.FindObjectOfType<GameManager>().GetComponent<TeamManager>()._teams.Count;
                string[] teams = new string[size];
                int cpt = 0;
                foreach (Team t in GameObject.FindObjectOfType<GameManager>().GetComponent<TeamManager>()._teams)
                {
                    teams[cpt] = t._name;
                    cpt++;
                }
                p.WriteStats(teams, teams[winner], size);
                written = true;
            }
        };

        _ends["RessourceRace"] = delegate ()
        {

        };
    }

    public void InitTests()
    {
        _tests["TestBot"] = delegate ()
        {
            List<int> teams = new List<int>();
            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            foreach (GameObject u in units)
            {
                if (u.GetComponent<Stats>()._unitType.Equals("Base"))
                {
                    if (!teams.Contains(u.GetComponent<Stats>()._teamIndex))
                        teams.Add(u.GetComponent<Stats>()._teamIndex);
                }
            }

            if (teams.Count == 1)
            {
                winner = teams[0];
                print("teamamanger : " + GameObject.Find("GameManager").GetComponent<TeamManager>()._teams[winner]._name);
                winnername = GameObject.Find("GameManager").GetComponent<TeamManager>()._teams[winner]._name;
            }
            print("Winner name :" + winnername);
            print("teams count : " + teams.Count);
            return teams.Count <= 1;
        };

        _tests["RessourceRace"] = delegate ()
        {
            return false;
        };
    }

    // Update is called once per frame
    void Update () {
        if (_tests[_gamename]())
            _ends[_gamename]();
	}
}
