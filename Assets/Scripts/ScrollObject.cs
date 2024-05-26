using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public bool canStop = false;
    public float speed;
    private float moveValue = -1f;
    public float startPosition;
    public float endPosition;

    private void Update()
    {
        DoScroll();
    }

    private void DoScroll()
    {
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
                transform.Translate(speed * moveValue * Time.deltaTime, 0, 0);
            }
        }
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
