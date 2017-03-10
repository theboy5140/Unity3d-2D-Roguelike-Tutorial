using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : BaseGameObject 
{
    public int width = 10;
    public int height = 10;
    public int foodTime = 1;
    public int enemyTime = 1;
    public int wallTime = 1;

    public GameObject exitTile;
    public GameObject playerTile;
    public GameObject[] floorTile;
    public GameObject[] wallTile;
    public GameObject[] outerWallTile;
    public GameObject[] foodTile;
    public GameObject[] enemyTile;

    private int level = 1;
    private List<Vector3> positions = new List<Vector3>();

    public void SetupScene(int level)
    {
        SetUpFloor ();
       
        this.level = level;

        SpawnItems ();
    }

    void SpawnItems()
    {
        int enemyCount = level * enemyTime;
        int foodCount = level * foodTime;
        int wallCount = level * wallTime;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnRandomTiles (enemyTile);
        }

        for (int n = 0; n < foodCount; n++) 
        {
            SpawnRandomTiles (foodTile);
        }

        for (int m = 0; m < wallCount; m++)
        {
            SpawnRandomTiles (wallTile);
        }

        SpawnRandomTile (playerTile);
    }

    // Spawn only one game tile item
    void SpawnRandomTile(GameObject tile)
    {
        int positionIndex = Random.Range (0, positions.Count);
        Vector3 position = positions [positionIndex];
        positions.RemoveAt (positionIndex);
        Instantiate (tile, position, Quaternion.identity);
    }

    // Spawn only one game title item ,but from a tile array
    void SpawnRandomTiles(GameObject[] tiles)
    {
        GameObject tile = tiles[Random.Range(0, tiles.Length)];
        int positionIndex = Random.Range (0, positions.Count);
        Vector3 position = positions [positionIndex];
        positions.RemoveAt (positionIndex);
        Instantiate (tile, position, Quaternion.identity);
    }

    void SetUpFloor()
    {
        positions.Clear ();
        
        for (int i = 0; i < width; i++)
        {
            for (int n = 0; n < height ; n++)
            {
                Vector3 position = new Vector3 (i, n, 0.0f);
                GameObject tile;

                if (0 == i || 0 == n || height - 1 == n || width - 1 == i) 
                {
                    tile = outerWallTile[Random.Range(0, outerWallTile.Length)];
                }
                else
                {
                    tile = floorTile[Random.Range(0, floorTile.Length)];
                    if (i == width - 2 && n == height - 2) 
                    {
                        tile = exitTile;
                    } else 
                    {
                        positions.Add (position);
                    }
                }
                Instantiate (tile, position, Quaternion.identity);
            }
        }
    }

    void Start()
    {
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
