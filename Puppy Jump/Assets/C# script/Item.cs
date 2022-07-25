using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject item;
    void Start()
    {
        InvokeRepeating("Spawn", 10.2f, 10.2f);
    }
    void Spawn()
    {
        float randomX = Random.Range(20, 30);
        Instantiate(item, new Vector3(randomX, -2.7f, 0f), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}