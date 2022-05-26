using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePiece : MonoBehaviour
{
    public int Row;
    public int Column;
    public int Depth;

    public void RecalculateCoords()
    {
        Row = (int)this.gameObject.transform.localPosition.z;
        Column = (int)this.gameObject.transform.localPosition.x;
        Depth = (int)this.gameObject.transform.localPosition.y;
    }

    private void Awake()
    {
        RecalculateCoords();
    }
}
