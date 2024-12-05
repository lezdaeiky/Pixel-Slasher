using UnityEngine;

public static class ObjectExtensions
{
    public static bool isOffScreen(this GameObject obj)
    {
        return obj.transform.position.y < -10f;
    }
}