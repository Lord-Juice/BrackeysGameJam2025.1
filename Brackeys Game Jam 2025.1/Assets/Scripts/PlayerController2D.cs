using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 0.5f;
    public float attackDamage = 10f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    
    public LayerMask enemyLayers;

    private Rigidbody2D rb;
    public Transform attackPoint;

    private Vector2 input;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame and used to get User Input
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    // FixedUpdate is used to calculate the physics
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
        if(input != Vector2.zero)
            attackPoint.SetPositionAndRotation(rb.position + input, Quaternion.identity);
    }

    void Attack() {
        // Collect all hit enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Deal damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().ReceiveDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
