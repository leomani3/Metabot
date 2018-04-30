﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traducteur : MonoBehaviour {
    string basictext;
    public string langue;
    public string textOriginal;
    public string traduction;
    public GameObject component;

    private GameObject gameManager;

    public void setTextOriginal(string s)
    {
        textOriginal = s;
        Traduction();
    }

    public void Traduction()
    {
        foreach (Langage l in gameManager.GetComponent<LangageLoader>().langues)
        {
            if (l.langue.Equals(langue))
            {
                foreach (Traduction t in l.trads)
                {
                    if (textOriginal.Equals(t.cle))
                    {
                        traduction = t.valeur;
                        return;
                    }
                }
            }
        }

        traduction = textOriginal;
    }

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");
        langue = gameManager.GetComponent<LangageLoader>().language;
        textOriginal = component.gameObject.GetComponent<Text>().text;
        basictext = textOriginal;
        Traduction();
        component.gameObject.GetComponent<Text>().text = traduction;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.GetComponent<LangageLoader>().language != langue)
        {
            langue = gameManager.GetComponent<LangageLoader>().language;
            Traduction();
            component.gameObject.GetComponent<Text>().text = traduction;
        }
	}
}
