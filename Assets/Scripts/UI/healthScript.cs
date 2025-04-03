using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public int health;

    public Text healthText;

    private void Update()
    {
        health.ToString();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            health -= 1;
        }
    }
}
