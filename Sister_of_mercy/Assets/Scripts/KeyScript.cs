using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [Header("��������� �����")]
    public GameObject keyObject;          
    private bool haveKey = false;          
    private bool canPickKey = false;       

    [Header("��������� �����")]
    public Animator doorAnimator;          
    public GameObject doorObject;          
    public bool nearDoor = false;         
    private bool isDoorOpen = false;       

    [Header("��������� ����������")]
    public KeyCode pickKeyButton = KeyCode.F;      
    public KeyCode interactDoorButton = KeyCode.F; 

    void Start()
    {
        if (doorAnimator == null && doorObject != null)
        {
            doorAnimator = doorObject.GetComponent<Animator>();
        }

        if (doorObject != null && doorObject.tag != "Door")
        {
            Debug.LogWarning("������ ����� ������ ����� ��� 'Door'!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ������ �����
        if (other.CompareTag("Player") && !haveKey)
        {
            canPickKey = true;
            Debug.Log("����� ����� � ������. ������� " + pickKeyButton + " ����� �����");
        }

        if (other.CompareTag("Door"))
        {
            nearDoor = true;
            if (haveKey)
            {
                Debug.Log("����� � ������. ������� " + interactDoorButton + " ����� �������/�������");
            }
            else
            {
                Debug.Log("����� ����, ����� ������� ��� �����");
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
            Debug.Log("����� ������ �� �����");
        }
    }

    void Update()
    {
        if (canPickKey && Input.GetKeyDown(pickKeyButton) && !haveKey)
        {
            PickUpKey();
        }

        if (haveKey && nearDoor && Input.GetKeyDown(interactDoorButton))
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

        Debug.Log("���� ��������! ������ ����� ������� �����");
    }

    void ToggleDoor()
    {
        if(haveKey && doorAnimator != null)
        {
            isDoorOpen = !isDoorOpen;
            doorAnimator.SetBool("open", isDoorOpen);
            
        }
       
    }

    public bool HasKey() { return haveKey; }
    public bool IsDoorOpen() { return isDoorOpen; }
}