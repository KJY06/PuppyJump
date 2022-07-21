using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy;
    public GameObject LEnemy;
    public GameObject AEnemy;
    public GameObject LAEnemy;
    [SerializeField] private float time;

    private void Awake()
    {
        time = 1.2f;
    }
    void SpawnEnemy()
    {
        int spawn = Random.Range(0, 4);
        float randomX = Random.Range(20, 30);
        if (enableSpawn)
        {
            if(spawn == 0)
            {
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, -2.7f, 0f), Quaternion.identity);
            }
            else if (spawn == 1)
            {
                GameObject enemy = (GameObject)Instantiate(LEnemy, new Vector3(randomX, -1.9f, 0f), Quaternion.identity);
            }
            else if (spawn == 2)
            {
                GameObject enemy = (GameObject)Instantiate(AEnemy, new Vector3(randomX, 0.1f, 0f), Quaternion.identity);
            }
            else if (spawn == 3)
            {
                GameObject enemy = (GameObject)Instantiate(LAEnemy, new Vector3(randomX, -2, 0f), Quaternion.identity);
            }
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, time);
    }
}