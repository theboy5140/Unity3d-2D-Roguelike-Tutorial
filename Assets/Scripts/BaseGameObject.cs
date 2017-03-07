using System;
using UnityEngine;

public class BaseGameObject : MonoBehaviour
{

    protected void Log(object message)
    {
        string logMessage = Time.time + " : "  + message;

        Debug.Log (logMessage);
    }
}

