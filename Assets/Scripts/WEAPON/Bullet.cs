using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        Vector2 NextPos = transform.position + new Vector3(0, 0.5f);
        GetComponent<Rigidbody2D>().MovePosition(NextPos);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "UFO")
        {
            GetComponent<AudioSource>().Play(0);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }




    }





}
