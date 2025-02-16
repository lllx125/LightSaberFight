using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{

    public GameObject Tile;
    public int tileScale;
    public int groundScale;

    void Start()
    {
        for (float i = groundScale * -1; i < groundScale + 1; i += tileScale)
        {
            for (float j = groundScale * -1; j < groundScale + 1; j += tileScale)
            {
                if (i < 1 && i > -1 && j < 1 && j > -1)
                {
                    continue;
                }
                Vector3 newCoord = new Vector3(i, 0.0f, j);
                Instantiate(Tile, newCoord, Quaternion.identity);
            }
        }

    }
}