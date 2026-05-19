using UnityEngine; // Это обязательная строка для работы MonoBehaviour

public class ItemsDoorScript : MonoBehaviour
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
        if(PickingScript.currentItems >= 10)
        {
            anim.SetBool("isOpen", trigger.isInTrigger);
        }
        
    }

}