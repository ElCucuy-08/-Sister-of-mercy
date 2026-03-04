using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorTriggerScript : MonoBehaviour
{
    public bool canOpen = false;
    void OnTriggerEnter(Collider other)
    {
        canOpen = true;
    }
    void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }
}
