using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationBehaviorScript : MonoBehaviour
{
    public Animator animator;
    public bool isWalking = false;
    public bool isRunning = false;
    public bool ishitting = false;

    public void Walk()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isHitting", false);
        isWalking = true;
        isRunning = false;
        ishitting = false;
    }
    public void Run()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", true);
        animator.SetBool("isHitting", false);
        isWalking = false;
        isRunning = true;
        ishitting = false;
    }
    public void Hit()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isHitting", true);
        isWalking = false;
        isRunning = false;
        ishitting = true;
    }
}
