using UnityEngine;

public static class Transforms
{
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t)
        {
            MonoBehaviour.Destroy(child.gameObject);
        }
    }
}
