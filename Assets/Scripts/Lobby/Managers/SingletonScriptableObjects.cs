using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptableObjects<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.LogError("ScriptableObjectsSingleton -> results = 0 " + typeof(T).ToString());
                    return null;
                }

                if (results.Length > 1)
                {
                    Debug.LogError("ScriptableObjectsSingleton -> results = 1 " + typeof(T).ToString());
                    return null;
                }

                _instance = results[0];
            }

            return _instance;
        }
    } 
}
