using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Сюда в инспекторе перетащите ваш объект с текстом
    [SerializeField] private GameObject interactionText;

    private bool canPickUp = false;

    private void Update()
    {
        // Если игрок в зоне и нажал F
        if (canPickUp && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(true); // Показываем текст
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(false); // Скрываем текст
            canPickUp = false;
        }
    }

    void PickUp()
    {
        Debug.Log("Предмет подобран!");
        interactionText.SetActive(false); // Скрываем текст перед удалением
        Destroy(gameObject);
    }
}
