                                        
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorOpenScript : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    public GameObject guiTextComponent;
    System.Random rnd = new System.Random();
    int numOfOpens = 0;
    public KeyScript key;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && canOpen /*&& key.isPicked*/)
        {
            
            if(numOfOpens == 0 && rnd.Next(0, 3) == 0)
            {
                isOpen = !isOpen;
                animator.SetBool("isOpen", true);
            }
            else if (numOfOpens == 1 && rnd.Next(0, 2) == 0)
            {
                isOpen = !isOpen;
                animator.SetBool("isOpen", true);
            }
            else if (numOfOpens == 2)
            {
                isOpen = !isOpen;
                animator.SetBool("isOpen", true);
            }
            numOfOpens++;
        }
    }
    public bool canOpen = false;
    void OnTriggerEnter(Collider other)
    {
        canOpen = true;
        //if (key.isPicked)
        //{
        //    guiTextComponent.gameObject.SetActive(true);
        //}
    }
    void OnTriggerExit(Collider other)
    {
        canOpen = false;
        guiTextComponent.gameObject.SetActive(false);
    }
}
