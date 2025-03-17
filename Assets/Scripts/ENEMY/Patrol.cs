using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // Create an array for the waypoints and drag them in the inspector
    [SerializeField]
    GameObject[] waypoints = new GameObject[5];

    [SerializeField]
    int indexOfNextWaypoint = 0;

    [SerializeField]
    public bool isPursuing = false;

    private void Update()
    {
       
       

        

        Vector3 moveTo = waypoints[indexOfNextWaypoint].transform.position;
        Vector3 direction = moveTo - transform.position;
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction.normalized;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Waypoint")
        {
            if (collision.gameObject == waypoints[indexOfNextWaypoint])
            {
                print("Reached waypoint " + indexOfNextWaypoint);
                indexOfNextWaypoint += 1;

            }
            if (indexOfNextWaypoint == waypoints.Length)
            {
                indexOfNextWaypoint = 0;
            }

            
        }





    }
}
