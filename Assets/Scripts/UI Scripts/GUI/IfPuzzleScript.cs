﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfPuzzleScript : MonoBehaviour
{
    public GameObject puzzleCondObject;
    public GameObject puzzleActionObject;
    public String validPlace = "false";
    public ManageDragAndDrop manager;
    Image image;
    Color defaultColor;
    Color validColor = new Color(158.0F / 255, 1, 79.0F / 255);

    public bool debugInstruction;
	// Use this for initialization
	void Start ()
    {
        manager = GetComponent<ManageDragAndDrop>();
        image = GetComponent<Image>();
        defaultColor = image.color;

    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateIfPuzzle();
        updateCondPuzzle();
        updateActionPuzzle();
        
        
        if (debugInstruction)
        {
            debugInstruction = false;
            Instruction I = createInstruction();
            print(I.toString());
        }
    }

    void updateCondPuzzle()
    {
        puzzleCondObject = null;
        foreach (GameObject puzzle in GameObject.FindGameObjectsWithTag("CondPuzzle"))
        {
            if (manager.posGridX + 1 == puzzle.GetComponent<ManageDragAndDrop>().posGridX && manager.posGridY == puzzle.GetComponent<ManageDragAndDrop>().posGridY)
            {
                puzzleCondObject = puzzle;
                break;
            }
        }
    }

    void updateActionPuzzle()
    {
        puzzleActionObject = null;
        foreach (GameObject puzzle in GameObject.FindGameObjectsWithTag("ActionPuzzle"))
        {
            if (manager.posGridX + 1 == puzzle.GetComponent<ManageDragAndDrop>().posGridX && manager.posGridY - 1 == puzzle.GetComponent<ManageDragAndDrop>().posGridY)
            {
                puzzleActionObject = puzzle;
                break;
            }
        }
    }

    void UpdateIfPuzzle()
    {
        image.color = defaultColor;
        validPlace = "false";

        GameObject startPuzzle = GameObject.FindGameObjectWithTag("StartPuzzle");
        foreach (GameObject puzzle in GameObject.FindGameObjectsWithTag("IfPuzzle"))
        {
            // startPuzzle.GetComponent<ManageDragAndDrop>().posGridX == -4
            // startPuzzle.GetComponent<ManageDragAndDrop>().posGridY == 3
            if (manager.posGridX == -4 && manager.posGridY + 1 == 3 
            ||
            manager.posGridX == puzzle.GetComponent<ManageDragAndDrop>().posGridX
            && manager.posGridY + 2 == puzzle.GetComponent<ManageDragAndDrop>().posGridY)
            {
                image.color = validColor;
                validPlace = "true";
                break;
            }
        }
            
    }

    /*
      behavior = new List<Instruction>(){
            new Instruction(new string[] { "PERCEPT_LIFE_NOT_MAX","PERCEPT_BAG_NOT_EMPTY"}, "ACTION_HEAL"),
            new Instruction(new string[] { "PERCEPT_BAG_25"}, "ACTION_CREATE_HEAVY"),
        new Instruction(new string[] { "PERCEPT_BAG_10"}, "ACTION_CREATE_LIGHT")};
        */

    public Instruction createInstruction()
    {
        List<string> percepts = new List<string>();
        string action = puzzleActionObject.GetComponent<ActionPuzzleScript>().actionName;
        GameObject condObjectCurrent = puzzleCondObject;
        while (condObjectCurrent != null)
        {
            percepts.Add(condObjectCurrent.GetComponent<CondPuzzleScript>().condName);
            condObjectCurrent = condObjectCurrent.GetComponent<CondPuzzleScript>().nextCondPuzzle;
        }
        print(percepts.Count);
        print(action);
        return new Instruction(percepts.ToArray(), action);
    }
}
