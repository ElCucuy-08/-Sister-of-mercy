                                        
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorOpenScript1 : MonoBehaviour
{

    public Animator animator;
    public GameObject door;

   
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
       
        door.animator.SetBool("isOpen", true);
       
    }
    void OnTriggerExit(Collider other)
    {
        
        door.animator.SetBool("isOpen", false);
    }
}
