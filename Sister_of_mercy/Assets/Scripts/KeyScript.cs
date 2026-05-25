using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [Header("Настройки ключа")]
    public GameObject keyObject;          
    private bool haveKey = false;          
    private bool canPickKey = false;       

    [Header("Настройки двери")]
    public Animator doorAnimator;          
    public GameObject doorObject;          
    public bool nearDoor = false;         
    private bool isDoorOpen = false;       

    [Header("Настройки управления")]
    public KeyCode pickKeyButton = KeyCode.F;      
    public KeyCode interactDoorButton = KeyCode.G; 

    void Start()
    {
        if (doorAnimator == null && doorObject != null)
        {
            doorAnimator = doorObject.GetComponent<Animator>();
        }

        if (doorObject != null && doorObject.tag != "Door")
        {
            Debug.LogWarning("Объект двери должен иметь тег 'Door'!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Подбор ключа
        if (other.CompareTag("Player") && !haveKey)
        {
            canPickKey = true;
            Debug.Log("Игрок рядом с ключом. Нажмите " + pickKeyButton + " чтобы взять");
        }

        if (other.CompareTag("Door"))
        {
            nearDoor = true;
            if (haveKey)
            {
                Debug.Log("Рядом с дверью. Нажмите " + interactDoorButton + " чтобы открыть/закрыть");
            }
            else
            {
                Debug.Log("Нужен ключ, чтобы открыть эту дверь");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickKey = false;
        }

        if (other.CompareTag("Door"))
        {
            nearDoor = false;
            Debug.Log("Игрок отошёл от двери");
        }
    }

    void Update()
    {
        if (canPickKey && Input.GetKeyDown(pickKeyButton) && !haveKey)
        {
            PickUpKey();
        }

        if (haveKey  && Input.GetKeyDown(interactDoorButton))
        {
            ToggleDoor();
        }
    }

    void PickUpKey()
    {
        haveKey = true;

        if (keyObject != null)
        {
            keyObject.SetActive(false); 
        }

        Debug.Log("Ключ подобран! Теперь можно открыть дверь");
    }

    void ToggleDoor()
    {
        if (doorAnimator != null)
        {
            isDoorOpen = !isDoorOpen;
            doorAnimator.SetBool("isOpen", isDoorOpen);
            Debug.Log(isDoorOpen ? "Дверь открыта" : "Дверь закрыта");
        }
        else
        {
            Debug.LogError("Аниматор двери не назначен!");
        }
    }

    public bool HasKey() { return haveKey; }
    public bool IsDoorOpen() { return isDoorOpen; }
}