using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFinish : MonoBehaviour
{
    bool active = false;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        active = true;
        if (active == true)
        {
            if (other.CompareTag("Finish"))
            {
                if (PickingScript.currentItems == PickingScript.maxItems)
                {
                    
                        SceneManager.LoadScene(5);
                    
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        active = false;
    }
}
