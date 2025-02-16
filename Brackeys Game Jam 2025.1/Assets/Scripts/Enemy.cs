using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    
    public float curHealth;

    void Start()
    {
        curHealth = maxHealth;
    }

    public void ReceiveDamage(float dmg) {
        curHealth -= dmg;

        if (curHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}
