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
        GameObject preloadRed = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        red = Instantiate(preloadRed, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        /*GameObject preloadGreen = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        green = Instantiate(preloadGreen, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        GameObject preloadBlue = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        blue = Instantiate(preloadBlue, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);

        GameObject preloadPink = Resources.Load<GameObject>("Prefab/Unit/WarBase");
        pink = Instantiate(preloadPink, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);*/

        red.GetComponent<WarBaseScript>().Instantiate(new MetaTeam("Red", "Assets/Resources/Team_Warbot/Test.wbt"));
        /*green.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Green", "Assets/Resources/Team_Warbot/Test.wbt"));
        blue.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Blue", "Assets/Resources/Team_Warbot/Test.wbt"));
        pink.GetComponent<WarBaseScript>().Instanciate(new MetaTeam("Pink", "Assets/Resources/Team_Warbot/Test.wbt"));*/
    }

    // Update is called once per frame
    void Update()
    {
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
