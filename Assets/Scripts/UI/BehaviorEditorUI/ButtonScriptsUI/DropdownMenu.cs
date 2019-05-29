using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class DropdownMenu : MonoBehaviour, IPointerClickHandler
{
    Dropdown dropDown;
    string path;

    public void Start()
    {
        path = Application.dataPath + "/StreamingAssets/teams/TestBot/";
        this.dropDown = this.gameObject.GetComponent<Dropdown>();
        if (this.gameObject.tag == "TeamChoiceList") FillTeamList();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.GetComponent<SaveToFile>().OnClick();
        this.gameObject.GetComponent<XmlTranslator>().OnClick();
    }

    public void FillTeamList()
    {
        this.dropDown = this.gameObject.GetComponent<Dropdown>();
        this.dropDown.options.Clear();

        DirectoryInfo di = new DirectoryInfo(path);
        FileInfo[] fileInfo = di.GetFiles();

        foreach (FileInfo file in fileInfo)
        {
            string name = file.Name;
            if (!name.EndsWith(".meta"))
            {
                //name.Remove(name.Length-5, 4);
                name = name.Replace(".wbt", "");
                this.dropDown.options.Add(new Dropdown.OptionData(name));
            }
        }
    }
}
