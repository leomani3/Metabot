﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PerceptCommon : Percept
{

    void Start()
    {
        InitPercept();
    }

    
    public override void InitPercept()
    {
        base.InitPercept();
        _percepts["PERCEPT_LIFE_MAX"] = delegate () { return GetComponent<Stats>()._maxHealth == GetComponent<Stats>()._health; };
        _percepts["PERCEPT_LIFE_75"] = delegate () { return GetComponent<Stats>()._health >= GetComponent<Stats>()._maxHealth * 0.75; };
        _percepts["PERCEPT_LIFE_50"] = delegate () { return GetComponent<Stats>()._health >= GetComponent<Stats>()._maxHealth * 0.50; };
        _percepts["PERCEPT_LIFE_25"] = delegate () { return GetComponent<Stats>()._health >= GetComponent<Stats>()._maxHealth * 0.25; };

        _percepts["PERCEPT_BAG_FULL"] = delegate () { return GetComponent<Inventory>()._maxSize == GetComponent<Inventory>()._actualSize; };
        _percepts["PERCEPT_BAG_EMPTY"] = delegate () { return GetComponent<Inventory>()._actualSize == 0; };
        _percepts["PERCEPT_BAG_10"] = delegate () { return GetComponent<Inventory>()._actualSize >= 10; };
        _percepts["PERCEPT_BAG_25"] = delegate () { return GetComponent<Inventory>()._actualSize >= 25; };

        _percepts["PERCEPT_ENEMY"] = delegate ()
        {
            
            Sight sight = GetComponent<Sight>();
            List<GameObject> _listOfUnitColl = new List<GameObject>();
            GetComponent<Stats>()._target = null;
            foreach (GameObject gO in sight._listOfCollision)
            {
                if (gO )
                {
                    if (gO.GetComponent<Stats>() && gO.GetComponent<Stats>()._teamIndex != GetComponent<Stats>()._teamIndex)
                    {
                        GetComponent<Stats>()._target = gO;
                        Transform canon = null;
                        for (int i = 0; i < transform.childCount - 1; i++)
                        {
                            if (transform.GetChild(i).transform.CompareTag("Canon"))
                            {
                                canon = transform.GetChild(i);
                            }
                        }


                        //If the child was found.
                        if (canon != null)
                        {
                            canon.eulerAngles = new Vector3(canon.eulerAngles.x, getAngle(gO)+180, canon.eulerAngles.z);
                           
                        }else GetComponent<Stats>()._heading = getAngle(gO);
                        return true;
                    }
                }
            }
            return false;
        };

        

        _percepts["PERCEPT_ALLY"] = delegate ()
        {
            Brain brain = GetComponent<Brain>();
            Sight sight = brain.GetComponent<Sight>();
            List<GameObject> _listOfUnitColl = new List<GameObject>();

            foreach (GameObject gO in sight._listOfCollision)
            {
                if (gO && !GetComponent<Stats>()._target)
                {
                    if (gO.GetComponent<Stats>() && gO.GetComponent<Stats>()._teamIndex == GetComponent<Stats>()._teamIndex)
                    {
                        GetComponent<Stats>()._target = gO;

                        GetComponent<Stats>()._heading = getAngle(gO);
                        return true;
                    }
                }
            }
            return false;
        };
    }

    public int getAngle(GameObject _gameObject)
    {
        Vector3 vect = _gameObject.transform.position - transform.position;
        Vector3 projVect = Vector3.ProjectOnPlane(vect, Vector3.up);

        if (projVect.z > 0)
        {
            return (int)(360 - Vector3.Angle(projVect, new Vector3(1, 0, 0)));
        }
        return (int)(Vector3.Angle(projVect, new Vector3(1, 0, 0)));

    }
}
