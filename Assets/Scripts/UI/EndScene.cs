using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndScreen")
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    
}
