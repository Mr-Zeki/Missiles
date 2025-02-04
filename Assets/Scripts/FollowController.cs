using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        var position = -offset + target.position;
        var currentPosition = Vector3.Lerp(transform.position, position, 0.5f);
        currentPosition.z = transform.position.z;
        transform.position = currentPosition;
    }
}
