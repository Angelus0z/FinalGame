using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour
{
    public Slider energySlider;
    public Slider easeEnergySlider;
    public float maxEnergy = 100f;
    public float energy;
    private float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (energySlider.value != energy)
        {
            energySlider.value = energy;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            LoseEnergy(10);
        }

        if (energySlider.value != easeEnergySlider.value)
        {
            easeEnergySlider.value = Mathf.Lerp(easeEnergySlider.value, energy, lerpSpeed);
        }
    }

    void LoseEnergy(float energyLoss)
    {
        energy -= energyLoss;
    }

    void GainEnergy(float energyGain)
    {
        energy += energyGain;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BatteryPickUp")
        {
            GainEnergy(50);
            Destroy(collision.gameObject);
        }

        if (energy >= 100)
        {
            energy = 100;
        }

        if (energy <= 0)
        {
            energy = 0;
        }

        
    }
}
