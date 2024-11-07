using System;
using Unity.Mathematics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Transform tilePrefab;

    [SerializeField] private int height = 22;
    [SerializeField] private int width = 10;

    private void Start()
    {
        CreateEmptySquare();
    }

    private void CreateEmptySquare()
    {
        if (tilePrefab != null)
        {
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Transform tile = Instantiate(tilePrefab, new Vector3(h, w, 0), quaternion.identity);
                    tile.name = "x " + h.ToString() + " , " + " y " + w.ToString();
                    tile.parent = transform;
                }
            }
        }
        else
        {
            print("TilePrefab eklenmedi!");
        }
        
    }
}
