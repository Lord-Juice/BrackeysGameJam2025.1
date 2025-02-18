using UnityEngine;

public class BulletEnemyBullet : MonoBehaviour
{
    public float bulletDamage = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            return;
        }
        // Instantiate Hiteffect

        // Damage Target
        collision.gameObject.GetComponent<HealthSystem>().ReceiveDamage(bulletDamage);
        // Destroy Bullet
        Destroy(gameObject);
    }
}
