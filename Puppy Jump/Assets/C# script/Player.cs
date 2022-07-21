using UnityEngine;

public class Player : MonoBehaviour
{
    public float jump = 6.4f;
    public GameObject Restart;
    private bool forjump = true;
    private bool forstart = false;
    private Animator animator;
    private int jumppoint;
    [SerializeField] private GameObject jumpplus;
    private Item i;
    private void Start()
    {
        i = FindObjectOfType<Item>();
        jumppoint = 1;
        Time.timeScale = 0;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();

        if (forjump == false)
            animator.SetBool("IsJump", true);
        else
            animator.SetBool("IsJump", false);
    }
    private void Move()
    {
        
        if (jumppoint > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                forjump = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                jumppoint--;

                if (forstart == false)
                {
                    forstart = true;
                    Time.timeScale = 1;
                }

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            forjump = true;
            if (jumppoint == 0)
            {
                jumppoint = 1;
                jumpplus.SetActive(false);
            }
            else
                jumppoint = 2;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            //Time.timeScale = 0;
           // Restart.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            jumpplus.SetActive(true);
            jumppoint = 2;
            i.forspawn = true;
            Destroy(collision.gameObject);
        }
    }
}
