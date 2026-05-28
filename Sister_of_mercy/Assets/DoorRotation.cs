using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorRotation : MonoBehaviour
{
    [SerializeField] public GameObject door;
    [SerializeField] private Rotate rotate;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;

        if (door != null)
        {
            door.transform.rotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
