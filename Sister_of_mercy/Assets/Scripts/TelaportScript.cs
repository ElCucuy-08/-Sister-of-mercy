using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TelaportScript : MonoBehaviour
{
    //GameObject spawnPoint;
    private GameObject currentItem;
    public int maxItems = 1;
    public int currentItems = 0;
    [SerializeField] Text Begin;
    [SerializeField] Text Takes;
    [SerializeField] Text Openthedoor;
    [SerializeField] Text Not;
    [SerializeField] GameObject key;
    bool take = false;
    bool openthedoor = false;
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
        if(take==true)
        {
            Takes.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {

                Takes.gameObject.SetActive(false);
                CanEnter = true;
                Destroy(key.gameObject);

            }
        }
        if(openthedoor==true)
        {
            if (CanEnter == true)
            {
                Openthedoor.gameObject.SetActive(true);
            }
            if (CanEnter == false)
            {
                Not.gameObject.SetActive(true);
            }
            if (CanEnter == true && Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(4);
                CanEnter = false;
            }
        }
        if (openthedoor == false)
        {
            Not.gameObject.SetActive(false);
            Openthedoor.gameObject.SetActive(false);
        }
            if (take==false)
        {
            Takes.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Begin.gameObject.SetActive(false);
        }
        //jgioevjds;vjpsk/
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    CanEnter = true;
        //}
        //fnrewiohgoearh
        if (other.CompareTag("Items"))
        {
            take = true;

            currentItem = other.gameObject;
        }
        if (other.CompareTag("Finish"))
        {
            openthedoor = true;

            currentItem = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            
            Takes.gameObject.SetActive(false);
            Not.gameObject.SetActive(false);
            Openthedoor.gameObject.SetActive(false);
            take = false;
            openthedoor=false;
    }

}
