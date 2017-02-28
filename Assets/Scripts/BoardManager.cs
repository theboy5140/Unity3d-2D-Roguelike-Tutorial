using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour 
{

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {   
            minimum = min;
            maximum = max;
        }
    }

    public class Actor
    {
        private GameObject gameObject;
        private Vector2 position;
        private Vector3 rotation;

        public Actor(GameObject gameObject, Vector2 position, Vector3 rotation)
        {
            this.gameObject = gameObject;
            this.position = position;
            this.rotation = rotation;
        }

        public Actor(GameObject gameObject, Vector2 position)
        {
            this.gameObject = gameObject;
            this.position = position;
            this.rotation = Vector3.zero;
        }

        public void SetParentTransform(Transform parent)
        {
            this.gameObject.transform.parent = parent;
        }
    }

    public int columns = 10;
    public int rows = 10;
    public Count wallCountRange = new Count(5, 9);
    public Count foodCountRange = new Count(1, 5);
    public Count enemyCountRange = new Count (1, 10);

    public GameObject exitTile;
    public GameObject[] enemyTile;
    public GameObject[] floorTile;
    public GameObject[] outerWallTile;
    public GameObject[] wallTile;
    public GameObject[] foodTile;

    private GameObject board;

    private void SpawnFloor()
    {
        for (int i = 1; i < columns - 1; i++) 
        {
            for (int n = 1; n < rows - 1; n++)
            {
                GameObject floorObject = floorTile[Random.Range(0, floorTile.Length)];
                GameObject floor = Instantiate (floorObject, new Vector3(i, n, 0.0f), Quaternion.identity);
                floor.transform.SetParent (board.transform);
            }
        }
    }

    private void SpawnOuterWalls()
    {
    }

    private void SpawnWalls()
    {}

    private void SpawnFood()
    {
    }

    private void SpawnEnemy()
    {
    }

    private void InitBoard()
    {
        SpawnFloor ();
        SpawnOuterWalls ();
        SpawnWalls ();
        SpawnFood ();
        SpawnEnemy ();
    }

    // Use this for initialization
	void Start () 
    {
        board = new GameObject ("Board");
        Instantiate (exitTile, new Vector3 (0, 0, 0f), Quaternion.identity);

        InitBoard ();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
