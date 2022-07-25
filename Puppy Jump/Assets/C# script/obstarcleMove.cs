using UnityEngine;
public class obstarcleMove : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}