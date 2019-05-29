using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectListButton : MonoBehaviour
{
    public GameObject componentButtonTemplate;
    protected Color colour;
    public GameObject dropdownMenu;

    protected Dictionary<string, ProcG> dicProc;

    protected List<string> listConditions;
    protected List<string> listProcedures;
    protected List<string> listMessages;
    protected List<string> listActionNT;
    protected List<string> listActionT;

    public void Start()
    {
        Debug.Log("Starting .... ");
        this.listProcedures = new List<string>();
        this.dicProc = new Dictionary<string, ProcG>();
    }

    public ProcG GetProcG(string name)
    {
        ProcG p;
        this.dicProc.TryGetValue(name, out p);
        return p;
    }

    protected void destroyButtons()
    {

        GameObject[] existingControles = GameObject.FindGameObjectsWithTag("ComponentButton");

        foreach(GameObject button in existingControles)
        {
            Destroy(button.gameObject);
        }
    }

    public void AddToProcedures(string name, ProcG pG)
    {
        this.listProcedures.Add(name);
        this.dicProc.Add(name, pG);
    }

    protected void remplissageLists() 
    {
        string unitType = "WarBase";
        Debug.Log("Filling lists");
        GameObject dropdownMenu;
        dropdownMenu = GameObject.FindWithTag("UnitChoiceList");
        int menuIndex = dropdownMenu.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = dropdownMenu.GetComponent<Dropdown>().options;
        unitType = menuOptions[menuIndex].text;

        Debug.Log("Unit type : " + unitType);

        switch (unitType)
        {
            case "WarBase" : 
                //IF WARBASE
                listConditions = new List<string>(new string[]{"Max health", "Health > 75", "Health > 50", "Health > 25", "Bag full", "Bag empty", "Not empty", "Ally near", "Enemy near", "Can Give"});
                listActionT = new List<string>(new string[]{"Heal", "Give", "Create Light", "Create Heavy", "Create Explorer"});
                break;

            case "WarExplorer" : 
                //IF WAREXPLORER
                listConditions = new List<string>(new string[]{"Max health", "Health > 75", "Health > 50", "Health > 25", "Bag full", "Bag empty", "Not empty", "Ally near", "Enemy near", "Ally Base near", "Can Give", "Ressource near"});
                listActionT = new List<string>(new string[]{"Heal", "Give", "Move", "Pick", "Random Move", "TurnAround Move", "Back to base", "Back to allies", "Move to enemy" });
                break;

            case "WarLight" : 
                //IF WARLIGHT
                listConditions = new List<string>(new string[]{"Max health", "Health > 75", "Health > 50", "Health > 25", "Bag full", "Bag empty", "Not empty", "Ally near", "Enemy near", "Ally Base near", "Can Give", "Ressource near"});
                listActionT = new List<string>(new string[]{"Shoot", "Heal", "Give", "Move", "Pick", "Random Move", "TurnAround Move", "Back to base", "Back to allies", "Move to enemy" });
                break;

            case "WarHeavy" :
                //IF WARHEAVY
                listConditions = new List<string>(new string[]{"Max health", "Health > 75", "Health > 50", "Health > 25", "Bag full", "Bag empty", "Not empty", "Ally near", "Enemy near", "Ally Base near", "Can Give", "Ressource near"});
                listActionT = new List<string>(new string[]{"Shoot", "Heal", "Give", "Move", "Pick", "Random Move", "TurnAround Move", "Back to base", "Back to allies", "Move to enemy" });
                break;

            default:
                listConditions = new List<string>(new string[]{});
                listActionT = new List<string>(new string[]{});
                break;
        }

    }

    public abstract void GenerateComponentButtons();
}
