using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// video for health bar below
// https://www.youtube.com/watch?v=3JjBJfoWDCM

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }

        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }

        if(health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "RobotEnemy")
        {
            takeDamage(10);
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }
}
