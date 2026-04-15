using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationBehaviorScript : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Walk();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Run();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Hit();
        }
    }

    public void Walk()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isHitting", false);
    }
    public void Run()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", true);
        animator.SetBool("isHitting", false);
    }
    public void Hit()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isHitting", true);
    }
}
