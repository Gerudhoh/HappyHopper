using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    IEnumerator Start()
    {
        var pos = transform.position;
        var pointA = pos;
        var pointB = new Vector2(pos.x-2.5f, pos.y);
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
