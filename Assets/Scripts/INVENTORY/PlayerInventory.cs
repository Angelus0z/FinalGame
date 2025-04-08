using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    Dictionary<string, int> inventory = new Dictionary<string, int>();
    [SerializeField]
    List<string> collectibles = new List<string>();

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the tag isn't in our collecibles list...
        if (!collectibles.Contains(collision.tag))
        {
            return;
        }


        
        if (inventory.ContainsKey(collision.tag))
        {


            inventory[collision.tag] += 1;
            print("you got more " + collision.tag + " : " + inventory[collision.tag]); 
            


        }
        else
        {
            inventory.Add(collision.tag, 1);
            print(collision.tag + " : " + inventory[collision.tag]);
            

        }

        Destroy(collision.gameObject);




    }












}
