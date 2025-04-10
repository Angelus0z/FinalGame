using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserDart : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    void Update()
    {
        Vector3 NextPos = transform.position + direction * 0.5f; 
        GetComponent<Rigidbody>().MovePosition(NextPos);

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Robot")
        {
            GetComponent<AudioSource>().Play(0);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }




    }





}

