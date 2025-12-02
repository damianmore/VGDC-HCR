using UnityEngine;

public class EnemyCarCollision : MonoBehaviour
{
    private movementcontrols playerMovement;
    private PowerUpProperties powerUpProperties;

    [SerializeField] private AudioSource hitCarSound;
    void Awake()
    {
        playerMovement = GameObject.FindFirstObjectByType<movementcontrols>();
        powerUpProperties = GameObject.FindFirstObjectByType<PowerUpProperties>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Mathf.Abs(transform.position.x - other.transform.position.x) > .5f) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Check if shield was active BEFORE calling TakeDamage
            bool shieldWasActive = powerUpProperties.IsShieldActive();
            powerUpProperties.TakeDamage();
            Destroy(other.gameObject);
            hitCarSound.Play();
            // Only game over if shield wasn't protecting
            if (!shieldWasActive)
            {
                Debug.Log("Game Over");
            }
            else
            {
                Debug.Log("Shield protected the player from slowdown!");
            }
        }
    }
}
