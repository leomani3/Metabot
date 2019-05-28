using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject loadingScreenBar;
    public Slider sliderLoad;
    public TeamMenuHUD[] DropDownList;
    public GameObject numberplayerDropDown;
    public Color[] playerColor;
    public int nbPlayers;

    public void StartGame()
    {
        
        nbPlayers = int.Parse(numberplayerDropDown.GetComponent<Dropdown>().captionText.text);
        //XMLWarbotInterpreter interpreter = new XMLWarbotInterpreter();

        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        string gamePath = Application.dataPath + "/Resources/Team_WarBot/";

        //set les settings
        gameManager.SetSetting();

        //Créer les teams
        for (int i = 0; i < nbPlayers; i++)
        {
            string name = DropDownList[i]._teamName;

            if (i == 0)
            {
                GameObject TeamBlue = GameObject.Find("TeamBlue");
                TeamBlue.GetComponent<TeamScript>().Team = new MetaTeam("Blue", gamePath + name + ".wbt");

                createUnitStart(TeamBlue, gameManager, 1);

                DontDestroyOnLoad(TeamBlue);
            }
            else if(i == 1)
            {
                GameObject TeamRed = GameObject.Find("TeamRed");
                TeamRed.GetComponent<TeamScript>().Team = new MetaTeam("Red", gamePath + name + ".wbt");

                createUnitStart(TeamRed, gameManager, 2);

                DontDestroyOnLoad(TeamRed);
            }
            else if (i == 2)
            {
                GameObject TeamGreen = GameObject.Find("TeamGreen");
                TeamGreen.GetComponent<TeamScript>().Team = new MetaTeam("Green", gamePath + name + ".wbt");

                createUnitStart(TeamGreen, gameManager, 3);

                DontDestroyOnLoad(TeamGreen);
            }
            else if (i == 3)
            {
                GameObject TeamYellow = GameObject.Find("TeamYellow");
                TeamYellow.GetComponent<TeamScript>().Team = new MetaTeam("Yellow", gamePath + name + ".wbt");

                createUnitStart(TeamYellow, gameManager, 4);

                DontDestroyOnLoad(TeamYellow);
            }
        } 
        StartCoroutine(AsynchronousLoad(gameManager._gameSettings._indexSceneMap));
    }

    IEnumerator AsynchronousLoad(int scene)
    {
        loadingScreenBar.SetActive(true);
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            sliderLoad.value = ao.progress;

            // Loading completed
            if (ao.progress == 0.9f)
            { 
               sliderLoad.value = 1f;
               ao.allowSceneActivation = true;

            }

            yield return null;
        }
    }

    void createUnitStart(GameObject team, GameManager gameManager, int teamId)
    {
        //Créer la base
        GameObject gameobject_base = Resources.Load<GameObject>("Prefab/Unit/WarBase" + team.GetComponent<TeamScript>().Team.teamName);
        Instantiate(gameobject_base, team.transform.position, Quaternion.identity, team.transform);
        //Créer les unités au début de la partie.
        foreach (KeyValuePair<string, int> unit in gameManager._gameSettings._initStartUnit)
        {
            for (int j = 0; j < unit.Value; j++)
            {
                //Les unités
                GameObject gameobject_unit = Resources.Load<GameObject>("Prefab/Unit/War" + unit.Key + team.GetComponent<TeamScript>().Team.teamName);
                Instantiate(gameobject_unit, team.transform.position, Quaternion.identity, team.transform);
            }
        }
        
    }
}
