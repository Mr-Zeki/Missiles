using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private Vector2 newDistance;
    [SerializeField] private Vector2 rangeScale;

    
    private void LateUpdate()
    {
        var distance = Vector3.Distance(PlayerController.instance.transform.position,transform.position);

        if (distance > maxDistance)
        {
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        transform.localScale = Vector3.one * Random.Range(rangeScale.x, rangeScale.y);

        var extra = (Vector3)(Random.insideUnitCircle.normalized * Random.Range(newDistance.x,newDistance.y));
        transform.position = PlayerController.instance.transform.position + extra;

    }
}
