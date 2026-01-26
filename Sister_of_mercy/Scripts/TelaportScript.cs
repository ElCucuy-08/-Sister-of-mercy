using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaportScript : MonoBehaviour
{
    GameObject spawnPoint;
    GameObject player;
    private void Start()
    {
        spawnPoint = GameObject.FindWithTag("Hall");
        player = GameObject.FindWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.gameObject.tag == "Player")
        {
            player.transform.position = spawnPoint.transform.position; 
        }
    }
}
