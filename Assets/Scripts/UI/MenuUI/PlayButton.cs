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
        XMLWarbotInterpreter interpreter = new XMLWarbotInterpreter();

        GameObject gameManager = GameObject.Find("GameManager");
        string gamePath = Application.streamingAssetsPath + "/teams/" + gameManager.GetComponent<GameManager>()._gameName + "/";
        
        gameManager.GetComponent<TeamManager>()._teams = new List<Team>();

        for (int i = 0; i < nbPlayers; i++)
        {
            string name = DropDownList[i]._teamName;
            MetaTeam team = new MetaTeam(name,gamePath + name + ".wbt" );
        }

        GameManager setting = gameManager.GetComponent<GameManager>();
        setting.SetSetting();

        StartCoroutine(AsynchronousLoad(setting._gameSettings._indexSceneMap));
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
}
