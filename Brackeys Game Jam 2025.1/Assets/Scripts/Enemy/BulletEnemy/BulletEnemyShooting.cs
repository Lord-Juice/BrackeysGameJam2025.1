using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public Transform target;
    public float attackRate = 0.5f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    private float nextAttackTime = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 lookDir = new Vector2(target.position.x - rb.position.x, target.position.y - rb.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.SetRotation(angle);

        // Attack
        if (Time.time >= nextAttackTime) {
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
