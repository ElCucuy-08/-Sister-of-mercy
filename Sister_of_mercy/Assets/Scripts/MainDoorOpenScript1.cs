using UnityEngine; // Это обязательная строка для работы MonoBehaviour

public class MainDoorOpenScript1 : MonoBehaviour
{
    // 1. Объявляем переменную для хранения ссылки на компонент
    private Animator anim;
    bool isOpen = false;
    public GameObject trigger;
    void Start()
    {
        // 2. Инициализируем ссылку при старте игры
        anim = trigger.GetComponent<Animator>();
    }

    void Update()
    {
        
        isOpen = !isOpen;
        anim.SetBool("isOpen",isOpen);
            
        
    }
    private void OnTriggerEnter(Collider other)
    {
        isOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isOpen =false;
    }
}