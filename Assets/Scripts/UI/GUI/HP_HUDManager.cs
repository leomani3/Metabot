﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_HUDManager : MonoBehaviour
{
    public GameObject _target;

    public float _value;
    public float _maxValue;
    public Text _HPText;
    public Image _HPImage;
    public Vector3 _delta;
    public Text _ressourceText;
    public Image _ressourceImage;
    public Objet ressource;
    public GameObject targetIcon;

    public HPColor[] _hpColor;
	
	// Update is called once per frame
	void Update ()
    {
        //Léo : J'ai commenté ça car nos unités n'implémentent pas encore les contrats
        /*if (_target)
        {
            targetIcon.SetActive(_target.gameObject.GetComponent<Stats>().HaveContrat());
        }*/

        if (!_target)
        {
            Destroy(gameObject);
        }
        else
        {
            if (_target.name.Contains("WarBase"))
            {
                _value = _target.GetComponent<WarBaseScript>().Unit.CurrentHealth;
                _maxValue = _target.GetComponent<WarBaseScript>().Unit.MaxHealth;
            }

            if (_target.name.Contains("WarLight"))
            {
                _value = _target.GetComponent<WarLightScript>().Unit.CurrentHealth;
                _maxValue = _target.GetComponent<WarLightScript>().Unit.MaxHealth;
            }

            if (_target.name.Contains("WarHeavy"))
            {
                _value = _target.GetComponent<WarHeavyScript>().Unit.CurrentHealth;
                _maxValue = _target.GetComponent<WarHeavyScript>().Unit.MaxHealth;
            }

            if (_target.name.Contains("WarExplorer"))
            {
                _value = _target.GetComponent<WarExplorerScript>().Unit.CurrentHealth;
                _maxValue = _target.GetComponent<WarExplorerScript>().Unit.MaxHealth;
            }
            
            _value = Mathf.Max(0, Mathf.Min(_maxValue, _value));
            _HPImage.fillAmount = (1.0f * _value) / _maxValue;
            _HPImage.color = HPColorUpdate(_HPImage.fillAmount);

            _HPText.text = "" + _value;
            
            transform.position = Camera.main.WorldToScreenPoint(_target.transform.position );
            transform.position += _delta;
            /*if (_target.GetComponent<Inventory>()._objets.ContainsKey(ressource) && _target.GetComponent<Inventory>()._objets[ressource] > 0 )
            {
                _ressourceImage.gameObject.SetActive(true);
                _ressourceText.gameObject.SetActive(true);
                _ressourceText.color = Color.white;
                if (_target.GetComponent<Inventory>()._actualSize == _target.GetComponent<Inventory>()._maxSize)
                {
                    _ressourceText.color = Color.magenta;
                }
                _ressourceText.text = "" + _target.GetComponent<Inventory>()._objets[ressource];
            }
            else
            {*/

                _ressourceImage.gameObject.SetActive(false);
                _ressourceText.gameObject.SetActive(false);
            //}
        }

        
	}


    public Color HPColorUpdate(float HPpercent)
    {
        Color color = _hpColor[0].color;
        for (int i = 1; i < _hpColor.Length; i++)
        {
            if (_hpColor[i - 1].hpPercent < HPpercent && HPpercent <= _hpColor[i].hpPercent) { return _hpColor[i].color; }
        }
        return color;
    }


}

[System.Serializable]
public struct HPColor
{
    [Range(0f,1f)]
    public float hpPercent;
    public Color color;
}