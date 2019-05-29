using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameManager), true)]
[CanEditMultipleObjects]

public class GameManagerEditorShow : Editor
{

    //UNUSED ?
    GameManager myTarget;

    void OnEnable()
    {
        myTarget = (GameManager)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Create Game File"))
        {
            myTarget.SaveGameFile();
        }

    }
}