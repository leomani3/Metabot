﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangementLangue(string newLangage)
    {
        GameObject.Find("GameManager").GetComponent<Traducteur>().langue = newLangage;
        GameObject.Find("GameManager").GetComponent<LangageLoader>().language = newLangage;
        string[] lines = System.IO.File.ReadAllLines("properties.yml");
        int cpt = 0;
        foreach (string line in lines)
        {
            if (line.Contains("Language"))
            {
                string[] tmp = line.Split('=');
                tmp[1] = newLangage;
                lines[cpt] = tmp[0] + "=" + tmp[1];
                break;
            }
            cpt++;
        }
        System.IO.File.WriteAllLines("properties.yml", lines);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
