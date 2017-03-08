using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseGameObject
{

    public static GameManager instance = null;
    public BoardManager boardManager;
    public GameObject player;

    public int level = 1;
    public bool playersTurn;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }else if(instance != this)
        {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        InitGame ();
    }

    void InitGame()
    {
        boardManager.SetupScene (level);
        Instantiate (player, new Vector2(2,2), Quaternion.identity);
    }
}
