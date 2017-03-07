using System;
using System.Collections;
using UnityEngine;

public abstract class MovableObject : BaseGameObject
{
    public LayerMask layerMask;
    public Rigidbody2D rb2d;
    public Collider2D collider;

    protected void Start()
    {
    }

    protected bool Move(Vector2 destination, RaycastHit2D hitObj)
    {
        bool result = false;

        Vector2 origin = gameObject.transform.position;

        collider.enabled = false;

        hitObj = Physics2D.Linecast (origin, destination, layerMask);

        if (hitObj.transform == null)
        {
            result = true;
        } 

        return result;
    }

    protected IEnumerator OnMove()
    {
        Log ("moving now");

        yield return new WaitForSeconds(1);   
    }

    protected virtual void OnAttemptMove <T> () where T : Component 
    {
        
    }

    protected abstract void OnCanotMove <T> () where T : Component;
}