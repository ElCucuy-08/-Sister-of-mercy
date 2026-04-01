using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private int destPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Убираем авто-торможение для плавности между точками
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void Update()
    {
        if (points.Length == 0) return;

        // 1. Постоянно обновляем цель, чтобы следовать за движущимся объектом
        agent.destination = points[destPoint].position;

        // 2. Проверяем достижение текущей динамической точки
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void GoToNextPoint()
    {
        if (points.Length == 0) return;
        agent.destination = points[destPoint].position;
    }
}
