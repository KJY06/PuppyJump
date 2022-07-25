using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private float jump;
    private int jumpcnt;

    private bool isfloor = true;
    private bool forstart = false;

    private Animator animator;
    
    [SerializeField] private GameObject chargeimage;
    [SerializeField] private GameObject Restart;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        jump = 17f;
        jumpcnt = 1;
    }
    void Update()
    {
        Jump();

        if (isfloor == false)
            animator.SetBool("IsJump", true);
        else
            animator.SetBool("IsJump", false);
    }
    void Gamestart()
    {
        if (forstart == false)
        {
            forstart = true;
            Time.timeScale = 1;
        }
    }
    private void Jump()
    {
        if (jumpcnt > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isfloor = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                jumpcnt--;
                Gamestart();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isfloor = true;
            if (jumpcnt == 0)
            {
                jumpcnt = 1;
                chargeimage.SetActive(false);
            }
            else
                jumpcnt = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            chargeimage.SetActive(true);
            jumpcnt = 2;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            Restart.SetActive(true);
        }
    }
}
