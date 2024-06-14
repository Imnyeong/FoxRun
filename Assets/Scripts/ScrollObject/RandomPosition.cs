using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] private float minH;
    [SerializeField] private float maxH;
    [SerializeField] private float minW;
    [SerializeField] private float maxW;

    void Start()
    {
        RandomPos();
    }
    public void RandomPos()
    {
        float h = Random.Range(minH, maxH);
        float w = Random.Range(minW, maxW);

        this.transform.localPosition = new Vector2(w, h);
    }
}
