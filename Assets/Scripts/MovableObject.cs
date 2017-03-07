using System;
using System.Collections;
using UnityEngine;

public abstract class MovableObject : BaseGameObject
{
    public LayerMask layerMask;
    public Rigidbody2D rb2d;
    public Collider2D collider;

    private float moveTime = 0.1f;
   
    protected void Start()
    {
    }

    protected bool Move(Vector2 destination, RaycastHit2D hitObj)
    {
        bool result = false;

        Vector2 origin = rb2d.pos;

        collider.enabled = false;

        hitObj = Physics2D.Linecast (origin, destination, layerMask);

        if (hitObj.transform == null)
        {
            StartCoroutine (OnMove(destination));
            result = true;
        } 
        return result;
    }

    protected IEnumerator OnMove(Vector2 destination)
    {
        float distance = (destination - rb2d.position).sqrMagnitude;
        //rb2d.MovePosition (destination);
        while (distance > float.Epsilon)
        {
            Vector2 newDestination = Vector2.MoveTowards (rb2d.position, destination, Time.fixedDeltaTime * 10);
            rb2d.MovePosition (newDestination);
            distance = (destination - rb2d.position).sqrMagnitude;
            yield return null;
        }
    }

    protected virtual void OnAttemptMove <T> () where T : Component 
    {
        
    }

    protected abstract void OnCanotMove <T> () where T : Component;
}