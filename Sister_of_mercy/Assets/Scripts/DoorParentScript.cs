using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParentScript : MonoBehaviour
{
    public bool isInTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }
}
