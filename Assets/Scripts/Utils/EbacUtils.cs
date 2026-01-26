using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
public static class EbacUtils
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Ebac/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }

    [UnityEditor.MenuItem("Ebac/Test2 %g")]
    public static void Test2()
    {
        Debug.Log("Test2");
    }
#endif

    public static void Scale(this Transform t, float size, float duration) => t.DOScale(Vector3.one * size, duration).SetEase(Ease.OutBack);

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}