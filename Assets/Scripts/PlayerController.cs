using System;
using UnityEngine;

class PlayerController : MovableObject
{
    public int damage = 1;

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
            OnAttemptMove<WallController> (horizontal, vertical);
        }
    }

    protected override bool OnAttemptMove<T> (int xDir, int yDir)
    {
        bool canMove = base.OnAttemptMove<T> (xDir, yDir);
        return canMove;
    }

    protected override void OnCannotMove<T>(T hitComponent)
    {
        WallController wall = hitComponent as WallController;
        Animator animator = GetComponent<Animator> ();
        animator.SetTrigger ("playerChop");
        wall.OnAttack (damage);
        Log ("wall life point remains : " + wall.lifePoint);
    }
}
