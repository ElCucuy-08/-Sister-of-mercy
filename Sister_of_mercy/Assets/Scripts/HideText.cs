using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideText : MonoBehaviour
{
    [SerializeField] Text Begin;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Begin.gameObject.SetActive(false);
        }
    }
}
