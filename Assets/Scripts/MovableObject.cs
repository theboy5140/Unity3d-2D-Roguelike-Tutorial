using System;
using System.Collections;
using UnityEngine;

public abstract class MovableObject : MonoBehaviour
{
    public LayerMask layerMask;

    protected void Start()
    {
        
    }

    protected bool Move(float x, float y, RaycastHit2D hitObj)
    {
        bool result = false;

        Vector2 origin = gameObject.transform.position;
        Vector2 destination = new Vector2 (x, y);
        hitObj = Physics2D.Linecast (origin, destination, layerMask);

        if (hitObj.transform == null)
        {
            StartCoroutine (OnMove());
        } else
        {
            result = false;
        }
        return result;
    }

    protected IEnumerator OnMove()
    {
        Debug.Log ("moving now");

        yield return WaitForSeconds (1);   
    }

    protected virtual void OnAttemptMove <T> () where T : Component 
    {
        
    }

    protected abstract void OnCanotMove <T> () where T : Component
    {
        
    }
}