using UnityEngine;

public class MonsterVision : MonoBehaviour
{
    public Transform target;      // Игрок
    public float viewRadius = 10f; // Радиус зрения
    [Range(0, 360)]
    public float viewAngle = 90f;  // Угол обзора
    public LayerMask obstacleMask; // Слой для стен/препятствий
    private MonsterAnimationBehaviorScript monsterScript;
    void Update()
    {
        if (CanSeeTarget())
        {
            Debug.Log("Вижу игрока!");
            //if(monsterScript.isRunning != false && CanSeeTarget() || Input.GetKeyDown(KeyCode.Y))
            //{
            //    monsterScript.Run();
            //    Debug.Log("Run");
            //}
            //if (monsterScript.isWalking != false && CanSeeTarget() == false)
            //{
                
            //    monsterScript.Walk();
            //}
        }

    }

    bool CanSeeTarget()
    {
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
}