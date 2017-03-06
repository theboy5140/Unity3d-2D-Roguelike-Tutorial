using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager boardManager;
    public int level = 1;

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
    }
}
