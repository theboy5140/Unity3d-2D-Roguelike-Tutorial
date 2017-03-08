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
        int horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
        int vertical = (int)(Input.GetAxisRaw ("Vertical"));

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (0 != horizontal || 0 != vertical)
        {
            OnAttemptMove<PlayerController> (horizontal, vertical);
        }

        Log (horizontal + ":" + vertical);
    }

    protected override void OnAttemptMove<T> (int xDir, int yDir)
    {
        base.OnAttemptMove<T> (xDir, yDir);
    }

    protected override void OnCanotMove<Wall>(Wall Component)
    {
        
    }
}
