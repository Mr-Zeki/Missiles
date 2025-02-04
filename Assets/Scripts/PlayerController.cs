using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private float _input;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        _input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * (moveSpeed * Time.fixedDeltaTime);
        rb.angularVelocity =  - _input * (rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missiles"))
        {
            //GameOver
            Time.timeScale = 0f;
        }
    }
}
