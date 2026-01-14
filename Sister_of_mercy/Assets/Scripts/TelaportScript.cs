using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TelaportScript : MonoBehaviour
{
    //GameObject spawnPoint;
    GameObject player;
    bool CanEnter = false;
    private void Start()
    {
        //spawnPoint = GameObject.FindWithTag("Hall");
        player = GameObject.FindWithTag("Player");
        
    }
    private void Update()
    {
        if (CanEnter && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("OnSideMap");
            CanEnter = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanEnter = true;
        }
    }
   
}
