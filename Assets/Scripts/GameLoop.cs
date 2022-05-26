using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public List<CubePiece> CubeList = new List<CubePiece>();

    private int _currentRowIndex = 0;
    private int _currentColumnIndex = 0;

    private bool _switch = false; //false is rows true is columns

    [SerializeField]
    List<GameObject> _rowHighLights;
    [SerializeField]
    List<GameObject> _columnHighLights;

    private bool _rotating = false;

    [SerializeField]
    private GameObject _centerPivot;

    private List<CubePiece> _selectedCubes = new List<CubePiece>();

    private void Awake()
    {
        CubePiece[] tempCubeList = GameObject.FindObjectsOfType<CubePiece>();

        foreach (CubePiece cube in tempCubeList)
        {
            CubeList.Add(cube);
        }
    }

    private void Update()
    {
        SelectionSwitch();
        if (_rotating == false)
        {
        CheckHighLights();

        }
    }

    private void SelectionSwitch()
    {
        if (Input.GetButtonDown("Select") && _rotating == false)
        {
            DeActivateHighlights();
            ReparentSelection();
            _rotating = true;
        }
        else if (Input.GetButtonDown("Select") && _rotating == true)
        {
            SnapToClosestPosition();
            UnparentSelection();
            ReActivateHighLights();
            _rotating = false;
        }
    }

   

    private void SnapToClosestPosition()
    {
       float nextX = Mathf.Round(_centerPivot.transform.rotation.x / 90f) * 90f;
        float nextY = Mathf.Round(_centerPivot.transform.rotation.y / 90f) * 90f;
        float nextZ = Mathf.Round(_centerPivot.transform.rotation.z / 90f) * 90f;

        _centerPivot.transform.rotation = Quaternion.Euler(nextX, nextY, nextZ);
    }

    private void UnparentSelection()
    {
        foreach (CubePiece cube in _selectedCubes)
        {
            cube.gameObject.transform.parent = null;
            cube.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            cube.RecalculateCoords();
        }
        _centerPivot.transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }

    private void ReparentSelection()
    {
        List<CubePiece> tempList = new List<CubePiece>();
        if (_switch == false)
        {
            tempList = SelectRow(_currentRowIndex);
        }
        if (_switch == true)
        {
            tempList = SelectColumn(_currentColumnIndex);
        }

        _selectedCubes = tempList;

        foreach (CubePiece cube in _selectedCubes)
        {
            cube.gameObject.transform.parent = _centerPivot.transform;
        }
    }

    private void CheckHighLights()
    {
       if (Input.GetButtonDown("Previous"))
        {
            DeCreaseIndex();
        }
       if (Input.GetButtonDown("Next"))
        {
            IncreaseIndex();
        }
       if (Input.GetButtonDown("Switch"))
        {
            Switch();
        }

    }

    private void DeActivateHighlights()
    {
        foreach (GameObject highLight in _rowHighLights)
        {
            highLight.SetActive(false);
        }
        foreach (GameObject highLight in _columnHighLights)
        {
            highLight.SetActive(false);
        }
    }

    private void ReActivateHighLights()
    {
        if (_switch == false)
        {
            RowHighLightUpdate();
        }
        if (_switch == true)
        {
            RowHighLightUpdate();
        }
    }

    private void IncreaseIndex()
    {
        if (_switch == false)
        {
            if (_currentRowIndex == (_rowHighLights.Count - 1))
            {
                _currentRowIndex = 0;
            }
            else
            {
                _currentRowIndex += 1;
            }
            RowHighLightUpdate();
        }

        if (_switch == true)
        {
            if (_currentColumnIndex == (_columnHighLights.Count - 1))
            {
                _currentColumnIndex = 0;
            }
            else
            {
                _currentColumnIndex += 1;
            }
            ColumnHighLightUpdate();
        }

    }



    private void DeCreaseIndex()
    {
        if (_switch == false)
        {
            if (_currentRowIndex == 0)
            {
                _currentRowIndex = (_rowHighLights.Count - 1);
            }
            else
            {
                _currentRowIndex -= 1;
            }
            RowHighLightUpdate();
        }

        if (_switch == true)
        {
            if (_currentColumnIndex == 0)
            {
                _currentColumnIndex = (_columnHighLights.Count - 1);
            }
            else
            {
                _currentColumnIndex -= 1;
            }
            ColumnHighLightUpdate();
        }
    }

    private void RowHighLightUpdate()
    {
        foreach (GameObject highLight in _rowHighLights)
        {
            highLight.SetActive(false);
        }

        _rowHighLights[_currentRowIndex].SetActive(true);

    }

    private void ColumnHighLightUpdate()
    {
        foreach (GameObject highLight in _columnHighLights)
        {
            highLight.SetActive(false);
        }

        _columnHighLights[_currentColumnIndex].SetActive(true);
    }

    private void Switch()
    {
        if (_switch == false)
        {
            foreach (GameObject highLight in _rowHighLights)
            {
                highLight.SetActive(false);
            }

            _columnHighLights[_currentColumnIndex].SetActive(true);
            _switch = true;
        }
        else if (_switch == true)
        {
            foreach (GameObject highLight in _columnHighLights)
            {
                highLight.SetActive(false);
            }

            _rowHighLights[_currentRowIndex].SetActive(true);
            _switch = false;
        }

    }

    public List<CubePiece> SelectRow(int row)
    {
        List<CubePiece> tempCubesList = new List<CubePiece>();
        foreach(CubePiece cube in CubeList)
        {
            if(cube.Row == row)
            {
                tempCubesList.Add(cube);
            }
        }
        return tempCubesList;

    }

    public List<CubePiece> SelectColumn(int column)
    {
        List<CubePiece> tempCubesList = new List<CubePiece>();
        foreach (CubePiece cube in CubeList)
        {
            if (cube.Column == column)
            {
                tempCubesList.Add(cube);
            }
        }
        return tempCubesList;
    }

    public List<CubePiece> SelectDepth(int depth)
    {
        List<CubePiece> tempCubesList = new List<CubePiece>();
        foreach (CubePiece cube in CubeList)
        {
            if (cube.Depth == depth)
            {
                tempCubesList.Add(cube);
            }
        }
        return tempCubesList;
    }









}
