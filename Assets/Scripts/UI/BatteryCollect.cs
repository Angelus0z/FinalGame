using UnityEngine;
using UnityEngine.UI;

public class BatteryCollect : MonoBehaviour
{
    int energy = -1;
    [SerializeField] Text batteryCollectText;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BatteryPickUp")
        {
            energy++;
            Destroy(collision.gameObject);
            batteryCollectText.text = "Energy: " + energy;
        }

        if (energy >= 4)
        {
            energy = 4;
        }

        if (energy <= 0)
        {
            energy = 0;
        }
    }
}
