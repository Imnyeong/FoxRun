using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public bool canStop = false;
    private const float moveValue = -1.0f;

    [SerializeField] private float speed;
    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;

    private Vector3 startVector3;

    private void Start()
    {
        startVector3 = new Vector3(moveValue * (endPosition - startPosition), 0, 0);
    }
    private void Update()
    {
        DoScroll();
    }

    private void DoScroll()
    {
        if (!GameManager.instance.isPlay)
            return;
        if (GameManager.instance.character.isCrouch && canStop)
            return;

        if (transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
        else
        {
            transform.Translate(speed * moveValue * Time.deltaTime, 0, 0);
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
            transform.Translate(startVector3);
        }
    }
}
