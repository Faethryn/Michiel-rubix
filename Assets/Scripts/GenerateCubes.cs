using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    [SerializeField]
    private int _radius;
    [SerializeField]
    private GameObject _location;

    [SerializeField]
    private GameLoop _gameloop;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < _radius; x++)
        {
                for (int y=0; y <_radius; y++)
            {
                for (int z = 0; z < _radius; z++)
                {
                    GameObject cube = Instantiate(_cube, new Vector3(x, y, z), _cube.transform.rotation, _location.gameObject.transform);
                    cube.name = $"Block {x}, {y}, {z}";
                    cube.GetComponent<CubePiece>().Row = z;
                    cube.GetComponent<CubePiece>().Column = y;
                    cube.GetComponent<CubePiece>().Depth = x;
                }
            }
        }
    }

    
}
