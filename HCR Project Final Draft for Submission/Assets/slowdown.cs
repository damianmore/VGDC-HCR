using UnityEngine;

public class slowdown : MonoBehaviour
{
    public float baseSpeed = 4f;
    public float slowMultiplier = 0.3f;
    public float slowDuration = 2f;

    private float currentMultiplier = 1f;
    private float slowTimer = 0f;
    private movementcontrols playerMovement;
    private PowerUpProperties powerUpProperties;

    [SerializeField] private AudioSource hitConeSound;

    void Awake()
    {
        playerMovement = GameObject.FindFirstObjectByType<movementcontrols>();
        powerUpProperties = GameObject.FindFirstObjectByType<PowerUpProperties>();
    }
    void Update()
    {
        
        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0)
            {
                currentMultiplier = 1f;
            }
        }

        playerMovement.forwardSpeed = baseSpeed * currentMultiplier * GameSpeedManager.GameSpeedMultiplier;
        //transform.position += new Vector3(0, 0, baseSpeed * currentMultiplier) * Time.deltaTime;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Ghost"))
        {         
            Debug.Log(col.gameObject.name);
            Debug.Log($"Player: {transform.position} | Cone: {col.gameObject.transform.position}");
            if (! col.CompareTag("Ghost")) return;
            if(Mathf.Abs(transform.position.x - col.transform.position.x) > .5f) return;
            
            Destroy(col.gameObject);
            hitConeSound.Play();
            
            // Check if shield was active BEFORE calling TakeDamage
            bool shieldWasActive = powerUpProperties.IsShieldActive();
            powerUpProperties.TakeDamage();
            // Only apply slowdown if shield wasn't protecting
            if (!shieldWasActive)
            {
                if(currentMultiplier == slowMultiplier) Debug.Log("Game Over");
                currentMultiplier = slowMultiplier;
                slowTimer = slowDuration;
            }
            else
            {
                Debug.Log("Shield protected the player from slowdown!");
            }
        }
    }
}