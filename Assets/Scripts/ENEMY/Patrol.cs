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

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    private float visualRange = 2f;

    [SerializeField]
    float fieldOfView = 45f;

   // [SerializeField]
    // float rotationSpeed = 2.0f;

    private void Update()
    {
        bool isInRange = Vector3.Distance(transform.position, Player.transform.position) < visualRange;
        Vector3 lineToPlayer = Player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, lineToPlayer);
        
        bool isInFOV = angleToPlayer < fieldOfView;

        Ray ray = new Ray(transform.position, lineToPlayer);
        bool hasLineOfSight = false;
        
        if (Physics.Raycast(ray, out var hit))
        {
            hasLineOfSight = hit.collider.gameObject == Player;
            print(hit.collider.name);
        }

        lineToPlayer.Normalize();

        lineToPlayer *= speed;

        if (isInRange && isInFOV && hasLineOfSight)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + lineToPlayer);
            isPursuing = true;
            transform.LookAt(Player.transform.position);
        }
        else
        {
            isPursuing = false;


        
        }
        
       // float rotationStop = rotationSpeed * Time.deltaTime;
        Vector3 moveTo = waypoints[indexOfNextWaypoint].transform.position;
        Vector3 direction = moveTo - transform.position;
        direction.Normalize();
        transform.LookAt(waypoints[indexOfNextWaypoint].transform.position);
        // Quaternion rotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().velocity = direction.normalized;

        
    }

  

    private void OnTriggerEnter(Collider collision)
    {
        //Quaternion WaypointDirection = Quaternion.LookRotation()
        if(!isPursuing)
        {
            if (collision.gameObject.tag == "Waypoint")
            {
                //transform.LookAt(waypoints[indexOfNextWaypoint].transform.position);
                if (collision.gameObject == waypoints[indexOfNextWaypoint])
                {

                    print("Reached waypoint " + indexOfNextWaypoint);
                    indexOfNextWaypoint += 1;
                    //transform.LookAt(waypoints[indexOfNextWaypoint].transform);

                }
                if (indexOfNextWaypoint == waypoints.Length)
                {
                    indexOfNextWaypoint = 0;
                  
                }

            }
        }





    }
}
