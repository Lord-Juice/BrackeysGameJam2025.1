using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    private float maxHealth;
    private float curHealth;
    
    public HealthSystem hs;
    public Slider healthBar;
    public TextMeshProUGUI healthBarText;

    public GameObject DeathScreen;

    void Update()
    {
        maxHealth = hs.maxHealth;
        curHealth = hs.curHealth;

        healthBar.value = curHealth;
        healthBarText.text = curHealth + "/" + maxHealth + " HP";

        if (curHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        // TODO: Add Kill Animation
        // Activate Deathscreen
        DeathScreen.SetActive(true);
        // Destroy the player
        Destroy(gameObject);
    }
}
