using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float force = 10f;

    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            shoot();
        }
    }

    void shoot()
    {
        Vector3 direction = (targetPosition - shootPoint.position);
        float distance = direction.magnitude;
        float angle = Mathf.Atan2(direction.y, direction.x);

        Vector2 velocity;
        velocity.x = Mathf.Cos(angle) * Mathf.Sqrt((distance * Physics2D.gravity.magnitude) / Mathf.Sin(2 * angle));
        velocity.y = Mathf.Sin(angle) * Mathf.Sqrt((distance * Physics2D.gravity.magnitude) / Mathf.Sin(2 * angle));

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }
}
