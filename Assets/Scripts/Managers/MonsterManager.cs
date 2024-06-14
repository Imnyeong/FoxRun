using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    private const int spawnValue = 10;
    private void FixedUpdate()
    {
        //if (ScoreManager.instance.score < spawnValue)
        //    return;
        //CheckLevel((int)(ScoreManager.instance.score / spawnValue));
    }
    private void CheckLevel(int _value)
    {
        //if (monsters[_value].activeSelf)
        //    return;
        //
        //monsters[_value].SetActive(true);
    }
}
