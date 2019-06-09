using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    IEnumerator Start()
    {
        var pos = transform.position;
        var pointA = pos;
        var pointB = new Vector2(pos.x, pos.y+6.5f);
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 2.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform transformation, Vector2 start, Vector2 end, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transformation.position = Vector2.Lerp(start, end, i);
            yield return null;
        }
    }
}
