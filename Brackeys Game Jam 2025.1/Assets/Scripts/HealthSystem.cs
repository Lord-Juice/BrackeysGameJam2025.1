using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float curHealth = 100f;

    void Start()
    {
        curHealth = maxHealth;
    }

    public void ReceiveDamage(float dmg) {
        // TODO: Add Damage animation

        // Subtracting the Damage from HP
        curHealth -= dmg;
        // have the player die, if he has 0 HP
        if (curHealth <= 0) {
            Die();
        }
    }

    public void Heal(float heal) {
        if (curHealth < maxHealth) {
            // TODO: Add Healing Animation
            // Add Health to HP
            curHealth += heal;
        }
    }

    private void Die() {
        // TODO: Add Kill Animation
        // Destroy the player
        Destroy(gameObject);
    }
}
