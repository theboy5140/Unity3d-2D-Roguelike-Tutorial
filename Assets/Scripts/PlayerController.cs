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
        ControlPlayer ();
    }

    protected override void OnCanotMove<T> ()
    {
    } 

    private void ControlPlayer()
    {
        Vector2 position = GetInput () + rb2d.position;
        RaycastHit2D hibObj = new RaycastHit2D ();
        bool canMove = Move (position, hibObj);
        if (canMove)
        {
            transform.position = position;
        }
    }

    private Vector2 GetInput()
    {
        float horizontal = Input.GetAxisRaw ("Horizontal");
        float vertical = Input.GetAxisRaw ("Vertical");
        Vector2 position = new Vector2 (horizontal, vertical);
        return position;
    }
}
