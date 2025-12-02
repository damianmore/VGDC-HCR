using UnityEngine;

public class ActivateShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(Mathf.Abs(transform.position.x - other.transform.position.x) > .5f) return;
        if (other.gameObject.CompareTag("Player"))
        {
            PowerUpProperties powerUp = other.gameObject.GetComponent<PowerUpProperties>();
            if (powerUp != null)
            {
                powerUp.ActivateShield();
                Destroy(gameObject); // Destroy the power-up after activation
            }
        }
    }
}
