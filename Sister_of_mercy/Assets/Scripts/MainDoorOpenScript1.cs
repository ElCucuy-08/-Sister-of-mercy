using UnityEngine; // Это обязательная строка для работы MonoBehaviour

public class MainDoorOpenScript1 : MonoBehaviour
{
    // 1. Объявляем переменную для хранения ссылки на компонент
    private Animator anim;
    bool isOpen = false;
    public DoorParentScript trigger;
    void Start()
    {
        // 2. Инициализируем ссылку при старте игры
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("isOpen",trigger.isInTrigger);
    }
    
}