using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpeningScript : MonoBehaviour
{
    public bool keyIsInInv = true;
    public Animator animator;
    public bool doorOpeningStage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyIsInInv && Input.GetKeyDown(KeyCode.F))
        {
            doorOpeningStage = !doorOpeningStage;
            animator.SetBool("doorOpeningStage", doorOpeningStage);
        }
    }
}
