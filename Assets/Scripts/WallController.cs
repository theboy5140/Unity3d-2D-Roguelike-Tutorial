using System;
using UnityEngine;

public class WallController : BaseGameObject
{
    public int lifePoint = 3;

    public void OnAttack(int damage)
    {
        //lifePoint -= damage;

        if (0 >= lifePoint)
        {
            gameObject.SetActive (false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }

   
}