using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float scrollSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
    }
}
