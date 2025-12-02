using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCarCollision : MonoBehaviour
{
    private movementcontrols playerMovement;
    private PowerUpProperties powerUpProperties;
    private bool hasCollided = false;

    [SerializeField] private AudioSource hitCarSound;
    void Awake()
    {
        playerMovement = GameObject.FindFirstObjectByType<movementcontrols>();
        powerUpProperties = GameObject.FindFirstObjectByType<PowerUpProperties>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (! col.CompareTag("Enemy")) return;
        if(Mathf.Abs(transform.position.x - col.transform.position.x) > .5f) return;
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Prevent multiple collisions from triggering multiple scene loads
            if (hasCollided) return;
            hasCollided = true;

            // Check if shield was active BEFORE calling TakeDamage
            bool shieldWasActive = powerUpProperties.IsShieldActive();
            powerUpProperties.TakeDamage();
            Destroy(col.gameObject);
            hitCarSound.Play();
            
            // Only game over if shield wasn't protecting
            if (!shieldWasActive)
            {
                SceneManager.LoadScene("End Screen"); // Load the scene synchronously
                hitCarSound.Play();
                Debug.Log("Game Over");
            }
            else
            {
                Debug.Log("Shield protected the player from collision!");
                hasCollided = false; // Reset for next collision if shield saved us
            }
        }
    }
}
