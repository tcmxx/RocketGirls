﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2D Vector of integer
/// </summary>
[System.Serializable]
public struct Vector2i
{
    public Vector2i(int x = 0, int y = 0)
    {
        this.x = x; this.y = y;
    }

    public int ManhattanDistanceTo(Vector2i goal)
    {
        return Mathf.Abs(goal.x - x) + Mathf.Abs(goal.y - y);
    }

    public bool Equals(Vector2i v)
    {
        return v.x == x && v.y == y;
    }
    public int x, y;
}


public static class MathUtils
{
    public enum InterpolateMethod
    {
        Linear,
        Log
    }

    /// <summary>
    /// interpolate between x1 and x2 to ty suing the interpolate method
    /// </summary>
    /// <param name="method"></param>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float Interpolate(float x1, float x2, float t, InterpolateMethod method = InterpolateMethod.Linear)
    {
        if (method == InterpolateMethod.Linear)
        {
            return Mathf.Lerp(x1, x2, t);
        }
        else
        {
            return Mathf.Pow(x1, 1 - t) * Mathf.Pow(x2, t);
        }
    }

    /// <summary>
    /// Return a index randomly. The probability if a index depends on the value in that list
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static int IndexByChance(float[] list)
    {
        float total = 0;

        foreach (var v in list)
        {
            total += v;
        }
        Debug.Assert(total > 0);

        float current = 0;
        float point = UnityEngine.Random.Range(0, total) ;

        for (int i = 0; i < list.Length; ++i)
        {
            current += list[i];
            if (current >= point)
            {
                return i;
            }
        }
        return 0;
    }
    /// <summary>
    /// return the index of the max value in the list
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static int IndexMax(float[] list)
    {
        int result = 0;
        for (int i = 1; i < list.Length; ++i)
        {
            if (list[i - 1] < list[i])
            {
                result = i;
            }
        }
        return result;
    }

    /// <summary>
    /// Shuffle a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="rnd"></param>
    public static void Shuffle<T>(IList<T> list, System.Random rnd)
    {
        int n = list.Count;
        while (n > 1)
        {

            n--;
            int k = rnd.Next(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

   
}