using System;
using System.Collections;
using UnityEngine;

public abstract class MovableObject : BaseGameObject
{
    public LayerMask layerMask;
    public Rigidbody2D rb2d;
    public Collider2D collider;

    private float moveTime = 0.1f;
    private float inverseMoveTime;

    protected void Start()
    {
        inverseMoveTime = 1 / moveTime;
    }

    protected bool Move(int xDir, int yDir, RaycastHit2D hitObj)
    {
        bool result = false;

        Vector2 origin = transform.position;

        Vector2 destination = origin +　new Vector2 (xDir, yDir);

        collider.enabled = false;

        hitObj = Physics2D.Linecast (origin, destination, layerMask);

        collider.enabled = true;

        if (hitObj.transform == null)
        {
            StartCoroutine (OnMove(destination));
            result = true;
        } 
        return result;
    }

    protected IEnumerator OnMove(Vector3 destination)
    {
        float distance = (transform.position - destination).sqrMagnitude;
        //rb2d.MovePosition (destination);
        while (distance > float.Epsilon)
        {
            Vector3 newDestination = Vector3.MoveTowards (transform.position, destination, Time.deltaTime);

            rb2d.MovePosition (newDestination);

            distance = (transform.position - destination).sqrMagnitude;

            yield return null;
        }
    }

    protected virtual void OnAttemptMove <T> () where T : Component 
    {
        
    }

    protected abstract void OnCanotMove <T> () where T : Component;
}