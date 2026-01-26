using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TelaportScript : MonoBehaviour
{
    //GameObject spawnPoint;
    private GameObject currentItem;
    public int maxItems = 1;
    public int currentItems = 0;
    //cdknslnvndslv
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
        if (Input.GetKeyDown(KeyCode.F) && currentItems < maxItems)
        {
            currentItems++;
            Destroy(currentItem);
        }
        //jgioevjds;vjpsk/
        if (CanEnter && Input.GetKeyDown(KeyCode.G) && currentItems == maxItems)
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
        //fnrewiohgoearh
        if (other.CompareTag("Items"))
        {
            currentItem = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            CanEnter = false;   
    }

}
