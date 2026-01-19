using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TelaportScript : MonoBehaviour
{
    //GameObject spawnPoint;
    GameObject player;
    bool CanEnter = false;
    public UnityEngine.UI.Text text;
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
        if (CanEnter)
        {
            text.gameObject.SetActive(true);
        }
        if (!CanEnter)
        {
            text.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanEnter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            CanEnter = false;
    }

}
