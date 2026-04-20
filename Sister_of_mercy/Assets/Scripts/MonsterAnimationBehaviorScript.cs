using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAnimationBehaviorScript : MonoBehaviour
{
    [SerializeField] private float angryRadius = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float wanderRadius = 15f;
    [SerializeField] private float wanderTimer = 3f;

    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;

    private float attackTimer = 0f;
    private float currentWanderTimer = 0f;
    private Vector3 wanderTarget;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
        SetNewWanderTarget();
        currentWanderTimer = wanderTimer;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        CheckCollision();

        if (distanceToPlayer <= angryRadius)
        {
            Run();
        }
        else
        {
            Wander();
        }
    }

    private void CheckCollision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 1.2f);
        foreach (var hit in hits)
        {
            if (hit.transform == player)
            {
                Hit();
                return;
            }
        }
    }

    private void Wander()
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }

        currentWanderTimer -= Time.deltaTime;

        if (currentWanderTimer <= 0 || Vector3.Distance(transform.position, wanderTarget) < 1f)
        {
            SetNewWanderTarget();
            currentWanderTimer = wanderTimer;
        }

        Vector3 direction = (wanderTarget - transform.position).normalized;
        transform.position += direction * (moveSpeed * 0.5f) * Time.deltaTime;

        if (direction != Vector3.zero)
            transform.forward = direction;
    }

    private void SetNewWanderTarget()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * wanderRadius;
        randomPoint.y = transform.position.y;
        wanderTarget = randomPoint;
    }

    private void Run()
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
            transform.forward = direction;
    }

    private void Hit()
    {
        if (attackTimer > 0) return;

        if (animator != null)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isHitting", true);
            animator.SetTrigger("Attack");
        }

        attackTimer = attackCooldown;
        Debug.Log("Монстр убил игрока! Перезагрузка...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, angryRadius);
    }
}
