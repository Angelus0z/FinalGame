using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    public Text KeyAmount;

    [SerializeField]
    GameObject[] doors = new GameObject[5];
    [SerializeField] Animator animator;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] private GameObject KeyUI;


    public int collectedKeys = 0;

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Key")
        {
            KeyUI.SetActive(true);
            collectedKeys++;
            print(collectedKeys);
            KeyAmount.GetComponent<Text>().text = " : " + collectedKeys;
            Destroy(collision.gameObject);

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

            }

            else
            {

                print("You need more keys to unlock the gate!");
                // collision.GetComponent<BoxCollider>().isTrigger = false;
            }


        }

        if (collision.tag == "OisinEnd" && collectedKeys >= 1)
        {
            collectedKeys--;
            print("This is working");
            SceneManager.LoadScene("Level2-Jude");
        }

        if (collision.tag == "End")
        {
            SceneManager.LoadScene("End Screen");
        }





    }
}