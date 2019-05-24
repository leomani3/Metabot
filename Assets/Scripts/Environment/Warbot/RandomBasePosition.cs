using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBasePosition : MonoBehaviour
{
    public GameObject[] teamPositions;
    public GameObject[] startUnitsPositions;

    //La fonction awake est appelée avant toutes les autres fonctions (avant Start par exemple)
    void Awake()
    {
        if (GameObject.Find("TeamBlue") != null)
        {
            GameObject TeamBlue = GameObject.Find("TeamBlue");
            TeamBlue.transform.position = teamPositions[0].transform.position;

            TeamBlue.GetComponentInChildren<WarBaseScript>().transform.position = TeamBlue.transform.position;

            foreach (Transform child in TeamBlue.transform)
            {
                if (!child.name.Contains("WarBase"))
                {
                    Debug.Log("BLBLBL    " + child.name);
                    float x = Random.Range(-startUnitsPositions[0].GetComponent<BoxCollider>().size.x, startUnitsPositions[0].GetComponent<BoxCollider>().size.x);
                    float y = TeamBlue.transform.position.y;
                    float z = Random.Range(-startUnitsPositions[0].GetComponent<BoxCollider>().size.z, startUnitsPositions[0].GetComponent<BoxCollider>().size.z);
                    child.transform.position = new Vector3(x, y, z);
                }
            }
        }
        if (GameObject.Find("TeamRed") != null)
        {
            GameObject TeamRed = GameObject.Find("TeamRed");
            TeamRed.transform.position = teamPositions[1].transform.position;
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
        /*for (int i = 0; i < teams.Length; i ++)
        {
            int j = Random.Range(0, teams.Length);

            GameObject t = teams[i];
            teams[i] = teams[j];
            teams[j] = t;
        }

        for (int i = 0; i < teams.Length; i++)
        {
            int j = Random.Range(0, teams.Length);
            teams[i].GetComponent<TeamPlayManagerScript>().teamIndex = i;
        }*/


    }
}
