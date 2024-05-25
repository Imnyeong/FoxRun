using System.Collections;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 1.0f;
    public float moveValue = -0.01f;
    public float startPosition;
    public float endPosition;

    public bool down = false;

    private float coroutineDelay = 0.01f;
    void Start()
    {
        StartCoroutine(ScrollCoroutine());
    }

    private IEnumerator ScrollCoroutine()
    {
        yield return new WaitForSecondsRealtime(coroutineDelay);

        if (!down)
        {
            if (transform.position.x <= endPosition)
            {
                ScrollEnd();
            }
            else
            {
                transform.Translate(speed * -0.01f, 0, 0);
            }
        }
        StartCoroutine(ScrollCoroutine());
    }
    void ScrollEnd()
    {
        transform.Translate(-1 * (endPosition - startPosition), 0 , 0);
    }
}
