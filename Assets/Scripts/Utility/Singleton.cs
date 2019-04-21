using System;
using UnityEngine;


/// <summary>
/// Base class for defining singleton MonoBehaviours.
/// </summary>
/// <typeparam name="T">The type of the singleton instance.</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Current
    {
        get
        {
            if (!HasSingleton)
                throw new NullReferenceException("Singleton reference not set to an instance of an object.");

            return (T)current;
        }
        set
        {
            if (!ReferenceEquals(value, null) && HasSingleton)
                throw new Exception("Singleton reference already set to an instance of an object.");

            current = value;
        }
    }
    public static bool HasSingleton
    {
        get
        {
            return !ReferenceEquals(current, null);
        }
    }

    private static MonoBehaviour current;

    protected virtual void Awake()
    {
        current = this;
    }
}
