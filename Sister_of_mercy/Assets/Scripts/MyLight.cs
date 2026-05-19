using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Light mylight;
    private void Start()
    {
        mylight.enabled = !mylight.enabled;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mylight.enabled = !mylight.enabled;
        }
    }
}
