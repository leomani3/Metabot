﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBasePosition : MonoBehaviour
{
    public GameObject[] teamPositions;

    //La fonction awake est appelée avant toutes les autres fonctions (avant Start par exemple)
    void Awake()
    {
        if (GameObject.Find("TeamBlue") != null)
        {
            GameObject TeamBlue = GameObject.Find("TeamBlue");
            TeamBlue.transform.position = teamPositions[0].transform.position;

            //on récupère les positions de spawn de la team
            List<Vector3> spawnPoints = TeamBlue.GetComponent<TeamScript>().spawnPoints;

            foreach (Transform child in TeamBlue.transform)
            {
            if (!child.name.Contains("WarBase"))
                {
                    if (spawnPoints.Count > 0)
                    {
                        child.transform.position = spawnPoints[0];
                        spawnPoints.RemoveAt(0);
                    }
                }
            }   
        }
        if (GameObject.Find("TeamRed") != null)
        {
            GameObject TeamRed = GameObject.Find("TeamRed");
            TeamRed.transform.position = teamPositions[1].transform.position;

            foreach (Transform child in TeamRed.transform)
            {
                if (!child.name.Contains("WarBase"))
                {
                    float x = -7;
                    float y = 0;
                    float z = 7;
                    child.transform.localPosition = new Vector3(x, y, z);
                }
            }
        }
        if (GameObject.Find("TeamGreen") != null)
        {
            GameObject TeamGreen = GameObject.Find("TeamGreen");
            TeamGreen.transform.position = teamPositions[2].transform.position;
        }
        if (GameObject.Find("TeamYellow") != null)
        {
            GameObject TeamYellow = GameObject.Find("TeamYellow");
            TeamYellow.transform.position = teamPositions[3].transform.position;
        }
    }
}
