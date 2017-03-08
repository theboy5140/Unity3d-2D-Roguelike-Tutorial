using System;
using UnityEngine;

class PlayerController : MovableObject
{
    void Start()
    {
        base.Start ();
    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
    }

    private void ProcessInput()
    {
        if (!GameManager.instance.playersTurn)
            return;
        
        int horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
        int vertical = (int)(Input.GetAxisRaw ("Vertical"));

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (0 != horizontal || 0 != vertical)
        {
            GameManager.instance.playersTurn = false;

            OnAttemptMove<PlayerController> (horizontal, vertical);
        }
    }

    protected override void OnAttemptMove<T> (int xDir, int yDir)
    {
        base.OnAttemptMove<T> (xDir, yDir);
    }

    protected override void OnCanotMove<Wall>(Wall Component)
    {
        
    }
}
