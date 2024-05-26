using System.Collections;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public bool canStop = false;
    public float speed = 1.0f;
    public float moveValue = -0.01f;
    public float startPosition;
    public float endPosition;

    private float coroutineDelay = 0.01f;
    void Start()
    {
        StartCoroutine(ScrollCoroutine());
    }

    private IEnumerator ScrollCoroutine()
    {
        yield return new WaitForSecondsRealtime(coroutineDelay);

        if (!GameManager.instance.isPlay || (Character.instance.isCrouch && canStop))
        {

        }
        else
        {
            if (transform.position.x <= endPosition)
            {
                ScrollEnd();
            }
            else
            {
                transform.Translate(speed * moveValue, 0, 0);
            }
        }
        StartCoroutine(ScrollCoroutine());
    }
    void ScrollEnd()
    {
        if (this.GetComponent<RandomPosition>() != null)
        {
            this.GetComponent<RandomPosition>().RandomPos();
        }
        else
        {
            transform.Translate(-1 * (endPosition - startPosition), 0, 0);
        }
    }
}
