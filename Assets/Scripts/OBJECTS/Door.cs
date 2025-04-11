using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*public GameObject DoubleDoorPrefab;
    [SerializeField] private ItemCollector itemCollector;

    private void Start()
    {
        itemCollector = DoubleDoorPrefab.GetComponent<ItemCollector>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (collectedKeys >= 1)
            {

                GetComponent<Animator>().Play("DoubleDoorOpen");
                collectedKeys--;
                //  GameObject.Find("KeyAmount").GetComponent<Text>().text = " : " + collectedKeys;
            }

            else
            {

                print("You need more keys to unlock the gate!");
                other.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }*/
}
