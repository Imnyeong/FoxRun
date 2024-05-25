using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float minH;
    public float maxH;
    public float minW;
    public float maxW;

    void Start()
    {
        RandomPos();
    }
    public void RandomPos()
    {
        float h = Random.Range(minH, maxH);
        float w = Random.Range(minW, maxW);

        this.transform.localPosition = new Vector3 (w, h, 0.0f);
    }
}
