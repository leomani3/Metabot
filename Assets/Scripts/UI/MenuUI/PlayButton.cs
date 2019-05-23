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
        Debug.Log("nbplayer :" + nbPlayers);
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
                TeamBlue.GetComponent<TeamScript>().Team = new MetaTeam("TeamBlue", gamePath + name + ".wbt");

                createUnitStart(TeamBlue, gameManager, 1);

                DontDestroyOnLoad(TeamBlue);
            }
            else if(i == 1)
            {
                GameObject TeamRed = GameObject.Find("TeamRed");
                TeamRed.GetComponent<TeamScript>().Team = new MetaTeam("TeamRed", gamePath + name + ".wbt");

                createUnitStart(TeamRed, gameManager, 2);

                DontDestroyOnLoad(TeamRed);
            }
            else if (i == 2)
            {
                GameObject TeamGreen = GameObject.Find("TeamGreen");
                TeamGreen.GetComponent<TeamScript>().Team = new MetaTeam("TeamGreen", gamePath + name + ".wbt");

                createUnitStart(TeamGreen, gameManager, 3);

                DontDestroyOnLoad(TeamGreen);
            }
            else if (i == 3)
            {
                GameObject TeamYellow = GameObject.Find("TeamYellow");
                TeamYellow.GetComponent<TeamScript>().Team = new MetaTeam("TeamYellow", gamePath + name + ".wbt");

                createUnitStart(TeamYellow, gameManager, 4);

                DontDestroyOnLoad(TeamYellow);
            }
        }
        Debug.Log("teams créée");
        
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
        //la base
        gameObject.AddComponent<CreatorUnit>().Create("Base", team, teamId);
        //Créer les unités au début de la partie.
        foreach (KeyValuePair<string, int> unit in gameManager._gameSettings._initStartUnit)
        {
            for (int j = 0; j < unit.Value; j++)
            {
                //Les unités
                gameObject.AddComponent<CreatorUnit>().Create(unit.Key, team, teamId);
            }
        }
        
    }
}
