using System;
using UnityEngine;

public class Singleton<T> where T : class, new()
{
    private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

    public static T Instance { get { return instance.Value; } }
}

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = (T)GameObject.FindObjectOfType(typeof(T));
                if (!instance)
                {
                    GameObject obj = new GameObject("GameManagers");
                    instance = obj.AddComponent(typeof(T)) as T;
                }
            }

            return instance;
        }
    }
}