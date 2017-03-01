using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour 
{
    public int width = 10;
    public int height = 10;
    public int foodTime = 1;
    public int enemyTime = 1;
    public int wallTime = 1;

    public GameObject exitTile;
    public GameObject[] floorTile;
    public GameObject[] wallTile;
    public GameObject[] outerWallTile;
    public GameObject[] foodTile;
    public GameObject[] enemyTile;

    private int level = 1;
    private List<Vector3> positions = new List<Vector3>();

    public void SetUpBoard(int level)
    {
        InitGround ();
        if (1 < level) 
        {
            this.level = level;        
        }
        InitLevelItem ();
    }

    void InitLevelItem()
    {
        int enemyCount = level * enemyTime;
        int foodCount = level * foodTime;
        int wallCount = level * wallTime;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnRandonTile (enemyTile);
        }

        for (int n = 0; n < foodCount; n++) 
        {
            SpawnRandonTile (foodTile);
        }

        for (int m = 0; m < wallCount; m++)
        {
            SpawnRandonTile (wallTile);
        }
    }

    void SpawnRandonTile(GameObject[] tiles)
    {
        GameObject tile = tiles[Random.Range(0, tiles.Length)];
        int positionIndex = Random.Range (0, positions.Count);
        Vector3 position = positions [positionIndex];
        positions.RemoveAt (positionIndex);
        Instantiate (tile, position, Quaternion.identity);
    }

    void InitGround()
    {
        positions.Clear ();
        
        for (int i = 0; i < height; i++)
        {
            for (int n = 0; n < width ; n++)
            {
                Vector3 position = new Vector3 (i, n, 0.0f);
                GameObject tile;

                if (0 == i || 0 == n || height - 1 == i || width - 1 == n) 
                {
                    tile = outerWallTile[Random.Range(0, outerWallTile.Length)];

                } else
                {
                    tile = floorTile[Random.Range(0, floorTile.Length)];
                    positions.Add (position);
                }
                Instantiate (tile, position, Quaternion.identity);
            }
        }
    }

    void Start()
    {
        SetUpBoard (1);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        
    }
}
