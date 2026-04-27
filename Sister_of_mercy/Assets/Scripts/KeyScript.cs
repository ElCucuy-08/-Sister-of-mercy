using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyScript : MonoBehaviour
{
    public bool isPicked = false;
    public bool canPick = false;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canPick && Input.GetKeyDown(KeyCode.F))
        {
            isPicked = true;
            key.transform.Translate(0, -30, 0);
        }
    }
}
