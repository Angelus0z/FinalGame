using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public Text KeyAmount;

    [SerializeField] PlayerInventory inventory;

    private int collectedKeys = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            collectedKeys++;
            Destroy(collision.gameObject);
            GameObject.Find("KeyAmount").GetComponent<Text>().text = " : " + collectedKeys;
        }

        if (collision.tag == "Gate")
        {
            if (collectedKeys >= 3)
            {
                
                Destroy(collision.gameObject);

                collectedKeys = 0;
                GameObject.Find("KeyAmount").GetComponent<Text>().text = " : " + collectedKeys;
            }

            else
            {
            
                print("You need more keys to unlock the gate!");
                collision.GetComponent<BoxCollider2D>().isTrigger = false;
            }


        }

        if (collision.tag =="End")
        {
            SceneManager.LoadScene("End Screen");
        }


    }
}