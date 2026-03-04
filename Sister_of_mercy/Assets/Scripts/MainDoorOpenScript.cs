using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorOpenScript : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    public GameObject guiTextComponent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canOpen)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
    }
    public bool canOpen = false;
    void OnTriggerEnter(Collider other)
    {
        canOpen = true;
        guiTextComponent.gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        canOpen = false;
        guiTextComponent.gameObject.SetActive(false);
    }
}
