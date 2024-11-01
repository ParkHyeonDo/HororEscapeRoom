using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            _instance?.GetComponent<T>();
            if (_instance == null)
            {
                _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                return _instance;
            }
            return _instance;
        }
    }
}
