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
        Vector2 screenPosition = GetInput ();
        Vector2 worldPisition = Camera.main.ScreenToWorldPoint (screenPosition);

        if (screenPosition != Vector2.zero)
        {
            RaycastHit2D hitObj = new RaycastHit2D ();
            bool canMove = Move (worldPisition, hitObj);
            Log (canMove);
        }
    }

    protected override void OnCanotMove<T> ()
    {
    } 

    private Vector2 GetInput()
    {
        Vector2 position = Vector2.zero;
        if (Input.GetMouseButtonDown (0)) 
        {
            position = Input.mousePosition;
        }
        return position;
    }
}
