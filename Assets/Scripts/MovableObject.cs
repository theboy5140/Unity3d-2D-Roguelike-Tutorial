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

        while (distance > float.Epsilon)
        {
            Vector3 position = Vector3.MoveTowards (rb2d.position, destination, Time.deltaTime * inverseMoveTime);

            rb2d.MovePosition (position);

            distance = (transform.position - destination).sqrMagnitude;

            yield return null;
        }
    }

    protected virtual void OnAttemptMove <T> (int xDir, int yDir) where T : Component 
    {
     
        RaycastHit2D hitObj = new RaycastHit2D ();

        bool canMove = Move (xDir, yDir, hitObj);

        if (null == hitObj.transform) 
        {
            return;
        } 
        else
        {
            T hitComponent = hitObj.transform.gameObject.GetComponent<T> ();

            if (null != hitObj && !canMove)
            {
                OnCanotMove<T> (hitComponent);
            }
        }
    }

    protected abstract void OnCanotMove <T> (T hitComponent) where T : Component;
}