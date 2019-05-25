using UnityEngine;

public class WorldTest : MonoBehaviour
{
    protected GameObject red;
    protected GameObject green;
    protected GameObject blue;
    protected GameObject pink;

    // Start is called before the first frame update
    void Start()
    {

        GameObject TeamRed = GameObject.Find("TeamRed");
        TeamRed.GetComponent<TeamScript>().Team = new MetaTeam("Red", "Assets/Resources/Team_Warbot/Test.wbt");

        GameObject TeamBlue = GameObject.Find("TeamBlue");
        TeamBlue.GetComponent<TeamScript>().Team = new MetaTeam("Blue", "Assets/Resources/Team_Warbot/Test.wbt");

        /*GameObject TeamRed = GameObject.Find("TeamRed");
        TeamRed.GetComponent<TeamScript>().Team = new MetaTeam("Red", "Assets/Resources/Team_Warbot/Test.wbt");*/
        
        GameObject preloadRed = Resources.Load<GameObject>("Prefab/Unit/WarBase" + TeamRed.GetComponent<TeamScript>().Team.teamName);
        red = Instantiate(preloadRed, new Vector3(30, 0.1f, 30), Quaternion.identity, TeamRed.transform);

        /*GameObject preloadGreen = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        green = Instantiate(preloadGreen, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);*/

        GameObject preloadBlue = Resources.Load<GameObject>("Prefab/Unit/WarBase" + TeamBlue.GetComponent<TeamScript>().Team.teamName);
        blue = Instantiate(preloadBlue, new Vector3(-30, 0.1f, -30), Quaternion.identity, TeamBlue.transform);

        /*GameObject preloadPink = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        pink = Instantiate(preloadPink, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);*/

        /*green.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Green", "Assets/Resources/Team_Warbot/Test.wbt"));
        blue.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Blue", "Assets/Resources/Team_Warbot/Test.wbt"));
        pink.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Pink", "Assets/Resources/Team_Warbot/Test.wbt"));*/
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(System.IO.Path.DirectorySeparatorChar);
    }

    public GameObject TeamRed
    {
        get { return red; }
    }

    public GameObject TeamGreen
    {
        get { return green; }
    }

    public GameObject TeamBlue
    {
        get { return blue; }
    }

    public GameObject TeamPink
    {
        get { return pink; }
    }
}
