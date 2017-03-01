﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager boardManager;

    private int level = 2;

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
        boardManager = GetComponent<BoardManager> ();
        InitGame ();
    }

    void InitGame()
    {
        boardManager.SetupScene (level);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
