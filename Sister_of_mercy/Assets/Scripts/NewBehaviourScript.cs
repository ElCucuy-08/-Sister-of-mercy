using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PickingScript : MonoBehaviour
{
    bool CanPickUp = false;
    public UnityEngine.UI.Text items;
    public int maxItems = 10;
    public int currentItems = 0;
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        items.text = $"{currentItems}/{maxItems} предметов собрано";
        
        if (CanPickUp && Input.GetKeyDown(KeyCode.F))
        {
            currentItems++;
            Destroy(item.gameObject);
        }
        if (currentItems == maxItems)
        {
            End();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Items")
        {
            CanPickUp = true;
            item = other.gameObject;
        }
    }

    public void End()
    {

    }
}
