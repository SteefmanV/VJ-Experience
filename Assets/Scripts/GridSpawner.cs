using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab = null;
    [SerializeField] private Vector3Int grid = new Vector3Int();
    [SerializeField] private Vector3 offset = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        generateGrid();
    }


    private void generateGrid()
    {
        for (int x = 0; x < grid.x; x++)
        {
            for (int y = 0; y < grid.y; y++)
            {
                for (int z = 0; z < grid.z; z++)
                {
                    Vector3 pos = new Vector3(x * offset.x, y * offset.y, z * offset.z);
                    Instantiate(_prefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}
