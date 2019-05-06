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
        red = new MetaTeam("Red", "Assets/Resources/Team_Warbot/Test.wbt");
        GameObject go = Resources.Load<GameObject>("Prefab/Unit/WarLight");
        Object.Instantiate(go, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public MetaTeam TeamRed
    {
        get { return red; }
    }
}
