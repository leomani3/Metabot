using UnityEngine;

public class WorldTest : MonoBehaviour
{
    protected MetaTeam red;
    protected MetaTeam green;
    protected MetaTeam blue;
    protected MetaTeam pink;

    // Start is called before the first frame update
    void Start()
    {
        red = new MetaTeam("Red", "Assets/Resources/Team_Warbot/Test.wbt",gameObject);
        green = new MetaTeam("Green", "Assets/Resources/Team_Warbot/Test.wbt", gameObject);
        blue = new MetaTeam("Blue", "Assets/Resources/Team_Warbot/Test.wbt", gameObject);
        pink = new MetaTeam("Pink", "Assets/Resources/Team_Warbot/Test.wbt", gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public MetaTeam TeamRed
    {
        get { return red; }
    }

    public MetaTeam TeamGreen
    {
        get { return green; }
    }

    public MetaTeam TeamBlue
    {
        get { return blue; }
    }

    public MetaTeam TeamPink
    {
        get { return pink; }
    }
}
