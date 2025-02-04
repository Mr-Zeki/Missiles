using System.Collections;
using UnityEngine;

public class MissilesController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [Range(1,20)][SerializeField] private float LifeTime;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D collider2d;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(LifeTime);
        Kill();
    }
    private void FixedUpdate()
    {
        var direction = PlayerController.instance.transform.position - transform.position;
        direction = direction.normalized;

        var rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.velocity = transform.up * (moveSpeed * Time.fixedDeltaTime);
        rb.angularVelocity = -rotateAmount * (rotateSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missiles"))
        {
            Kill();
        }
    }

    private void Kill()
    {
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        moveSpeed = 0;
    }
}