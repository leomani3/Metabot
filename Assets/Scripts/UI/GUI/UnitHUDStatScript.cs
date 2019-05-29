using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHUDStatScript : MonoBehaviour
{
    public GameObject cameraUnit;

    public Text _healthText;
    public Image _healthFillImage;
    public Image _bagFillImage;
    public Text _itemText;
    public Text _headingText;
    public HeadingShower headingShower;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraUnit = Camera.main.GetComponent<SubjectiveCamera>().unit;
        if (cameraUnit != null)
        {
            Unit unit = cameraUnit.GetComponent<UnitScript>().Unit;
            _healthText.text = "" + unit.CurrentHealth + "/" + unit.MaxHealth;
            _itemText.text = "" + unit.CurrentBagSize + "/" + unit.MaxBagSize;
            _headingText.text = "" + (int)unit.Heading + "°";
            headingShower.angle = unit.Heading;

            _healthFillImage.fillAmount = 1.0f * unit.CurrentHealth / unit.MaxHealth;
            _bagFillImage.fillAmount = 1.0f * unit.CurrentBagSize / unit.MaxBagSize;
        }
    }
}
