using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    int[] damages = new int[20];
    [SerializeField]
    AudioClip[] clips = new AudioClip[3];




    void Update()
    {

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            int randIndex = Random.Range(0, clips.Length);
            AudioClip randClip = clips[randIndex];
            GetComponent<AudioSource>().clip = randClip;
            GetComponent<AudioSource>().Play();
        }


        
    }
}
