using UnityEngine;

public class SpownManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;

    void SpawnEnemy()
    {
        int spawn = Random.Range(0, 4);
        float randomX = Random.Range(20, 30);
        if (spawn == 0)
        {
            Instantiate(Enemy[0], new Vector3(randomX, -2.7f, 0f), Quaternion.identity);
        }
        else if (spawn == 1)
        {
            Instantiate(Enemy[1], new Vector3(randomX, -1.9f, 0f), Quaternion.identity);
        }
        else if (spawn == 2)
        {
            Instantiate(Enemy[2], new Vector3(randomX, 0.1f, 0f), Quaternion.identity);
        }
        else if (spawn == 3)
        {
            Instantiate(Enemy[3], new Vector3(randomX, -2, 0f), Quaternion.identity);
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1.2f);
    }
}