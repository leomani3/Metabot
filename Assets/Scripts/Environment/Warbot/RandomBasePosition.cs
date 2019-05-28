using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBasePosition : MonoBehaviour
{
    public GameObject[] teamPositions;

    //La fonction awake est appelée avant toutes les autres fonctions (avant Start par exemple)
    void Awake()
    {
        //PLACEMENT DE LA TEAM BLEUE
        if (GameObject.Find("TeamBlue") != null)
        {
            GameObject TeamBlue = GameObject.Find("TeamBlue");

            //placement de la base
            TeamBlue.transform.position = teamPositions[0].transform.position;

            //stratégie : on place les unités autours de la base à un angle "angle" et une distance "distance"
            float angle = 0;
            float distance = 10;
            for (int i=0; i<TeamBlue.transform.childCount; i++)
            {
                //Tous les enfants de la team (aka les unités de début)
                Transform child = TeamBlue.transform.GetChild(i);

                //On ne souhaite pas déplacere la base
                if (!child.name.Contains("WarBase"))
                {
                    float x = distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                    float y = TeamBlue.transform.position.y;
                    float z = distance * Mathf.Sin(Mathf.Deg2Rad * angle);

                    child.localPosition = new Vector3(x, y, z);
                    angle += 35;

                    //Si on a compléter un tour complet autours de la base, on augmente la distance et on refait un tour
                    if(angle >= 360)
                    {
                        distance += 5;
                        angle = 0;
                    }
                }
            }
        }
        if (GameObject.Find("TeamRed") != null)
        {
            GameObject TeamRed = GameObject.Find("TeamRed");
            TeamRed.transform.position = teamPositions[1].transform.position;

            float angle = 0;
            float distance = 10;
            for (int i = 0; i < TeamRed.transform.childCount; i++)
            {
                Transform child = TeamRed.transform.GetChild(i);

                if (!child.name.Contains("WarBase"))
                {
                    float x = distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                    float y = 0;
                    float z = distance * Mathf.Sin(Mathf.Deg2Rad * angle);

                    child.localPosition = new Vector3(x, y, z);
                    angle += 35;

                    if (angle >= 360)
                    {
                        distance += 5;
                        angle = 0;
                    }
                }
            }
        }
        if (GameObject.Find("TeamGreen") != null)
        {
            GameObject TeamGreen = GameObject.Find("TeamGreen");
            TeamGreen.transform.position = teamPositions[2].transform.position;

            float angle = 0;
            float distance = 10;
            for (int i = 0; i < TeamGreen.transform.childCount; i++)
            {
                Transform child = TeamGreen.transform.GetChild(i);

                if (!child.name.Contains("WarBase"))
                {
                    float x = distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                    float y = 0;
                    float z = distance * Mathf.Sin(Mathf.Deg2Rad * angle);

                    child.localPosition = new Vector3(x, y, z);
                    angle += 35;

                    if (angle >= 360)
                    {
                        distance += 5;
                        angle = 0;
                    }
                }
            }
        }
        if (GameObject.Find("TeamYellow") != null)
        {
            GameObject TeamYellow = GameObject.Find("TeamYellow");
            TeamYellow.transform.position = teamPositions[3].transform.position;

            float angle = 0;
            float distance = 10;
            for (int i = 0; i < TeamYellow.transform.childCount; i++)
            {
                Transform child = TeamYellow.transform.GetChild(i);

                if (!child.name.Contains("WarBase"))
                {
                    float x = distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                    float y = 0;
                    float z = distance * Mathf.Sin(Mathf.Deg2Rad * angle);

                    child.localPosition = new Vector3(x, y, z);
                    angle += 35;

                    if (angle >= 360)
                    {
                        distance += 5;
                        angle = 0;
                    }
                }
            }
        }
    }
}
