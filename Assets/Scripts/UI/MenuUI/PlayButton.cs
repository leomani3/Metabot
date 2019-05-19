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

        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        string gamePath = Application.streamingAssetsPath + "/teams/" + gameManager._gameName + "/";
        
        //Créer les teams
        for (int i = 0; i < nbPlayers; i++)
        {
            string name = DropDownList[i]._teamName;
            //MetaTeam team = new MetaTeam(name,gamePath + name + ".wbt" );
        }

        //Créer les unités au début de la partie.
        foreach (KeyValuePair<string, int> unit in gameManager._gameSettings._initStartUnit)
        {
            for (int i = 0; i < unit.Value; i++)
            {
                GetComponent<CreatorUnit>().Create(unit.Key);
            }
        }

        gameManager.SetSetting();

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
}
