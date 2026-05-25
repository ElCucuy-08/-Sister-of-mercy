using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInDoorTriggerScript : MonoBehaviour
{
    public KeyScript key;
    private void OnTriggerEnter(Collider other)
    {
        key.nearDoor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        key.nearDoor = false;
    }
}
