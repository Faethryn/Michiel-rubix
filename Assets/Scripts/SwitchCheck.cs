using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchCheck : MonoBehaviour
{
    public bool _switch; //true = rows, false = columns
    public bool Detected;
    
    //public static bool _validation;
    public List<GameObject> _listRowsinit;
    public List<GameObject> _listColsinit;

    public List<GameObject> _listRows;
    public List<GameObject> _listCols;
    public LayerMask _rowLayer;
    public LayerMask _colLayer;
    public SelectionType _type;
    public static SelectionType Switch;

    // Start is called before the first frame update
    public void Start()
    {
        _switch = false;
        Switch = SelectionType.Row;
    }

    public void Update()
    {
        _type = Switch;
    }

    public void OnTriggerEnter(Collider other)
    {
        

        if (((1 << other.gameObject.layer) & _rowLayer) != 0)
        {
            _listRowsinit.Add(other.gameObject);

        }



        if (((1 << other.gameObject.layer) & _colLayer) != 0)
        {
            _listColsinit.Add(other.gameObject);

        }

    }


    public void OnTriggerStay(Collider other)
    {


        if (Detected)
        {

            if (_switch == true)
            {
                _listCols.Clear();
                _listCols.AddRange(_listColsinit);
                

                _listRows.Clear();
            }
            else
            {

                _listRows.Clear();
                _listRows.AddRange(_listRowsinit);

                _listCols.Clear();

            }

            Detected = false;
        }

        if(_listRows != null)
        {
            Switch = SelectionType.Row;
        }

        if(_listCols !=null)
        {
            Switch = SelectionType.Column;
        }
    }
}
