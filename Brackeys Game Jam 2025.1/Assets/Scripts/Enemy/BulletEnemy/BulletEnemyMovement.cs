using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletEnemyMovement : MonoBehaviour
{
    /* 
        This class handles the movement of the Bullet Enemy
        It should stand still for a few seconds and then move in a direction for a couple of seconds
    */

    public float idleTime = 5f;
    public float moveTime = 3f;
    public float moveSpeed = 5f;

    private bool isMoving = true;
    public float currentCycleTime = 0f;
    private Vector2 moveDir;

    private Rigidbody2D rb;

    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GetComponent<BulletEnemyController>().target;
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDir);
    }

    void FixedUpdate()
    {
        currentCycleTime += Time.fixedDeltaTime;

        if (isMoving)
        {
            if (currentCycleTime < moveTime)
            {
                Move();
            }
            else
            {
                // Finished moving, start idling
                isMoving = false;
                currentCycleTime = 0f;
                Debug.Log("Switching to idle");
            }
        }
        else
        {
            if (currentCycleTime >= idleTime)
            {
                // Finished idling, start moving
                moveDir = CalculateMoveDir();
                isMoving = true;
                currentCycleTime = 0f;
                Debug.Log("Switching to moving");
            }
        }
    }

    Vector2 CalculateMoveDir() {
        Vector2 toTarget = (target.position - transform.position).normalized;
        Vector2 perpendicular = new Vector2(-toTarget.y, toTarget.x);
        float randomAngle = Random.Range(-22.5f, 22.5f);
        float rad = randomAngle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        Vector2 rotated = new Vector2(perpendicular.x * cos - perpendicular.y * sin, perpendicular.x * sin + perpendicular.y * cos);
        if (Random.value < 0.5f)
            rotated = -rotated;
        return rotated.normalized;
    }
}