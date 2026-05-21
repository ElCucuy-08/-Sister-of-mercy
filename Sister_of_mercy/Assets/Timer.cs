using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    void Start()
    {
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
