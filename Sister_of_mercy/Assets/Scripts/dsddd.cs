using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dsddd : MonoBehaviour
{
    public Light light1;
    // Start is called before the first frame update
    void Start()
    {
        light1 = GetComponent<Light>();
        light1.intensity = 0f;
    }
    bool isLighting = false;
    public float maxIns = 1f;
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.E))
        {
            isLighting = !isLighting;
            

        }
        if (isLighting)
        {
            light1.intensity = Mathf.Lerp(0f, maxIns, 0.1f);
        }
        else
        {
            light1.intensity = Mathf.Lerp(maxIns, 0f, 0.1f);
        }
    }
}
