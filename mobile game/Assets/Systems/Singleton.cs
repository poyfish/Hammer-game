using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public T Instance;

    /// <summary>
    ///  returns false if there was an existing singleton, returns true otherwise
    /// </summary>

    public bool InitializeSingleton(T singleton)
    {
        if (GameObject.FindObjectsOfType<Singleton<T>>().Length > 1)
        {
            Destroy(this.gameObject);
            return false;
        }

        Instance = singleton;

        return true;
    }
}
