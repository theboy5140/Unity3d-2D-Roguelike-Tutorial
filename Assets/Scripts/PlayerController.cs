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
    }

    void FixedUpdate()
    {
        ProcessInput();
    }

    protected override void OnCanotMove<T> ()
    {
    } 

    private void ProcessInput()
    {
        int xDir = (int)(Input.GetAxisRaw ("Horizontal"));
        int yDir = (int)(Input.GetAxisRaw ("Vertical"));
        RaycastHit2D hitObj = new RaycastHit2D ();
        bool canMove = Move (xDir, yDir, hitObj);
        Log (xDir + ":" + yDir);
    }

}
