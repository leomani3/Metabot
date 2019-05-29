﻿using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Brain))]
[CanEditMultipleObjects]
public class BrainEditorShow : Editor
{
    //UNUSED ?
    Brain myTarget;

    void OnEnable()
    {
        myTarget = (Brain)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Brain myTarget = (Brain)target;
        GUILayout.Label("Current Action :", EditorStyles.boldLabel);
        if (myTarget._instructions != null)
        {
            EditorGUILayout.LabelField(">>> " + myTarget.NextAction());
        }
    }
}