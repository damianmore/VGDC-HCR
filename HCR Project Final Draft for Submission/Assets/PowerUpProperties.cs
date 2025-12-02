using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour
{
   public GameObject shield;
    private bool _isShieldActive = false;
    public float _shieldDuration = 5f; // Shield duration in seconds

    void Start()
    {
        shield.SetActive(false); // Ensure shield is off initially
    }

    public void ActivateShield()
    {
        if (!_isShieldActive)
        {
            _isShieldActive = true;
            shield.SetActive(true);
            StartCoroutine(DeactivateShieldAfterDelay(_shieldDuration));
        }
    }

    IEnumerator DeactivateShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isShieldActive = false;
        shield.SetActive(false);
    }

    public void TakeDamage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            shield.SetActive(false);
            Debug.Log("Shield absorbed damage!");
        }
        else
        {
            // Apply regular damage logic
            Debug.Log("Player took damage!");
        }
    }

    /// <summary>
    /// Returns whether the shield is currently active
    /// </summary>
    public bool IsShieldActive()
    {
        return _isShieldActive;
    }
}
