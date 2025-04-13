using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //public Text KeyAmount;
    [SerializeField]
    GameObject[] doors = new GameObject[5];
    [SerializeField] Animator animator;
    [SerializeField] PlayerInventory inventory;

  
    public int collectedKeys = 0;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Key")
        {
            collectedKeys++;
            print(collectedKeys);
            Destroy(collision.gameObject);

           // GameObject.Find("KeyAmount").GetComponent<Text>().text = " : " + collectedKeys;
        }

       if (collision.tag == "Gate")
        {
            if (collectedKeys >= 1)
            {

                Animator doorAnimator = collision.GetComponent<Animator>();
                doorAnimator.Play("DoubleDoorOpen");

                collectedKeys--;

                BoxCollider doorCollider = collision.GetComponent<BoxCollider>();
                doorCollider.isTrigger = true;

                GameObject doorLock = GameObject.Find("DoorLock");
                Destroy(doorLock);
               
                

                //  GameObject.Find("KeyAmount").GetComponent<Text>().text = " : " + collectedKeys;
            }

           else
            {
            
                print("You need more keys to unlock the gate!");
               // collision.GetComponent<BoxCollider>().isTrigger = false;
            }


        }

        if (collision.tag =="End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
        
           
        
    }
}