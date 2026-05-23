using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterPatrolWithVision : MonoBehaviour
{
    [Header("Настройки патрулирования")]
    public Transform[] points;           // Точки патрулирования
    public float waitAtPointTime = 1f;   // Время ожидания на точке
    private NavMeshAgent agent;
    private int destPoint = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    [Header("Настройки зрения")]
    public Transform target;             // Игрок
    public float viewRadius = 10f;       // Радиус зрения
    [Range(0, 360)]
    public float viewAngle = 90f;        // Угол обзора
    public LayerMask obstacleMask;       // Слой для стен/препятствий

    [Header("Настройки преследования")]
    public float chaseSpeed = 5f;        // Скорость преследования
    public float patrolSpeed = 2f;       // Скорость патрулирования
    public float attackRadius = 1.5f;    // Радиус атаки
    public float attackCooldown = 1f;    // Задержка между атаками
    public int damage = 10;              // Урон от атаки
    public double timer = 10;              // Урон от атаки

    private bool isChasing = false;      // Преследует ли игрока
    private bool isAttacking = false;
    private float lastAttackTime;
    private float originalSpeed;          // Для сохранения оригинальной скорости


    [SerializeField] public Text text;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        originalSpeed = patrolSpeed;
        agent.speed = patrolSpeed;

        lastAttackTime = -attackCooldown;

        // Если цель не назначена, пытаемся найти игрока по тегу
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                target = playerObj.transform;
        }

        // Запускаем патрулирование
        GoToNextPoint();
    }

    private void Update()
    {
        if (target == null) return;

        // Проверяем, видит ли монстр игрока
        bool canSeePlayer = CanSeeTarget();

        if (canSeePlayer)
        {
            timer = 2;
            viewAngle = 360;
        }
        if (timer>0)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            // Если видит игрока - начинаем преследование
            if (!isChasing)
            {
                StartChasing();
            }

            // Проверяем, в радиусе ли атаки
            if (distanceToPlayer <= attackRadius)
            {
                // Атакуем
                if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack();
                }
                // Останавливаемся при атаке
                agent.isStopped = true;
            }
            else
            {
                // Преследуем игрока
                agent.isStopped = false;
                agent.destination = target.position;
            }
        }
        else
        {
            // Если был в режиме преследования, но потерял игрока
            if (isChasing)
            {
                StopChasing();
            }

            // Патрулируем
            Patrol();
            viewAngle = 90;
        }
        timer = timer - Time.deltaTime;
    }

    private void Patrol()
    {
        if (points.Length == 0) return;

        // Обработка ожидания на точке
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                GoToNextPoint();
            }
            return;
        }

        // Проверяем достижение текущей точки
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                waitTimer = waitAtPointTime;
                agent.isStopped = true;
            }
        }
        else
        {
            agent.isStopped = false;
        }
    }

    private void StartChasing()
    {
        isChasing = true;
        agent.speed = chaseSpeed;
        Debug.Log("Монстр заметил игрока и начал преследование!");
    }

    private void StopChasing()
    {
        isChasing = false;
        agent.speed = patrolSpeed;

        // Возвращаемся к патрулированию с ближайшей точки
        if (points.Length > 0)
        {
            FindClosestPatrolPoint();
            isWaiting = false;
        }

        Debug.Log("Монстр потерял игрока, возвращается к патрулированию.");
    }

    private void FindClosestPatrolPoint()
    {
        float closestDistance = Mathf.Infinity;
        int closestIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, points[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        destPoint = closestIndex;
        agent.destination = points[destPoint].position;
    }

    private void GoToNextPoint()
    {
        if (points.Length == 0) return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    private void Attack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        // Наносим урон игроку
        //PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        //if (playerHealth != null)
        //{
        //    playerHealth.TakeDamage(damage);
        //    Debug.Log($"Монстр атаковал игрока! Нанесено {damage} урона");
        //}
        Debug.Log("Монстр убил игрока! Перезагрузка...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //text.text = "0/10 предметов собрано";
        // Сбрасываем состояние атаки через время
        Invoke(nameof(ResetAttack), 0.5f);
        PickingScript.currentItems = 0;
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    private bool CanSeeTarget()
    {
        if (target == null) return false;

        // 1. Проверка дистанции
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > viewRadius) return false;

        // 2. Проверка угла
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, directionToTarget) > viewAngle / 2) return false;

        // 3. Проверка преград (Raycast)
        if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
        {
            return false; // Луч попал в стену
        }

        return true; // Все проверки пройдены
    }

    // Визуализация в редакторе
    private void OnDrawGizmosSelected()
    {
        // Радиус зрения
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // Радиус атаки
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        // Конус зрения
        if (target != null)
        {
            Gizmos.color = Color.green;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Gizmos.DrawLine(transform.position, transform.position + directionToTarget * viewRadius);
        }

        // Точки патрулирования
        if (points != null && points.Length > 0)
        {
            Gizmos.color = Color.blue;
            foreach (Transform point in points)
            {
                if (point != null)
                    Gizmos.DrawWireSphere(point.position, 0.5f);
            }
        }
    }
}

