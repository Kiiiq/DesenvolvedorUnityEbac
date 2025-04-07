using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KiqUtils
{
    public static T randomObject<T>(this List<T> list) { 
        return list[Random.Range(0, list.Count)];
    }

    public static T randomObject<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
