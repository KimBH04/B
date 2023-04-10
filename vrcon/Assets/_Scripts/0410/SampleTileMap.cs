using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTileMap : MonoBehaviour
{
    public GameObject tile_001, tile_002;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject temp = Instantiate(tile_001);
                temp.transform.position = new Vector3(i, 0, j);
            }

            for (int j = 10; j < 20; j++)
            {
                GameObject temp = Instantiate(tile_002);
                temp.transform.position = new Vector3(i, 0, j);
            }
        }
    }
}
