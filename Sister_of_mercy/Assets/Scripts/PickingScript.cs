using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PickingScript : MonoBehaviour
{
    private bool CanPickUp = false;
    private GameObject currentItem; 
    public Text itemsText; 
    public static int maxItems = 10;
    public static int currentItems = 0;

    void Update()
    {
        itemsText.text = $"{currentItems}/{maxItems} предметов собрано";

        if (CanPickUp && Input.GetKeyDown(KeyCode.F) && currentItems < maxItems)
        {
            currentItems++;
            Destroy(currentItem);
            CanPickUp = false;
        }

        if (currentItems >= maxItems)
        {
            End();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Items"))
        {
            CanPickUp = true;
            currentItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Items"))
        {
            CanPickUp = false;
        }
    }

    public void End()
    {
        
    }
}
