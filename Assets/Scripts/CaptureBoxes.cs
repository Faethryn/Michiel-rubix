using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureBoxes : MonoBehaviour
{
    public SelectionType _type;
    public List<Rigidbody> _objectList;
    public LayerMask _interactables;
    public GameObject _location;

    public void OnEnable()
    {

    }

    // Start is called before the first frame update
    public void RetrieveAllObjects()
    {
        
    }

    public void RemoveAllObjects()
    {

    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (((1 << other.gameObject.layer) & _interactables) != 0)
    //    {
    //        //if (other.gameObject.transform.parent = gameObject.transform)
    //        //{

    //        //}
    //        //else
    //        //{
    //            if (SwitchCheck.Switch.Equals(_type))
    //            {
    //                //add all objects list
    //                _objectList.Add(other.gameObject.GetComponent<Rigidbody>());
    //                //put all objects under gameobject so if under effect, they move with
    //                other.gameObject.transform.SetParent(_location.transform);
    //                //print(other.gameObject.name + " added");
    //            }
    //        //}
    //    }
    //    else
    //    {

    //    }
    //}

    public void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & _interactables) != 0)
        {
            if (other.gameObject.transform.parent = gameObject.transform)
            {

            }
            else
            {
                if (SwitchCheck.Switch.Equals(_type))
                {
                    //add all objects list
                    _objectList.Add(other.gameObject.GetComponent<Rigidbody>());
                    //put all objects under gameobject so if under effect, they move with
                    other.gameObject.transform.SetParent(_location.transform);
                    //print(other.gameObject.name + " added");
                }
            
            }
        }
        else
        {

        }
    }


}
