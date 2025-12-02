using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public static float GameSpeedMultiplier { get; private set; } = 1f;
    public float initialSpeed = 1f;
    public float accelerationRate = 0.0001f;
    public float maxSpeedMultiplier = 5f;
    public float startDelay = 20f;
    private float timeElapsed = 0f;
    private bool startSpeedingUp = false;

    void Start()
    {
        ResetSpeed();
    }

    void Update()
    {
        if (!startSpeedingUp)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= startDelay)
            {
                startSpeedingUp = true;
            }
            return;
        }
        if (GameSpeedMultiplier < maxSpeedMultiplier)
        {
            GameSpeedMultiplier += accelerationRate * Time.deltaTime;
            Debug.Log($"Game Speed Multiplier: {GameSpeedMultiplier}");
            GameSpeedMultiplier = Mathf.Clamp(GameSpeedMultiplier, initialSpeed, maxSpeedMultiplier);
        }
    }

    public void ResetSpeed()
    {
        GameSpeedManager managerInstance = FindObjectOfType<GameSpeedManager>();
        if (managerInstance != null)
        {
            GameSpeedMultiplier = managerInstance.initialSpeed;
            managerInstance.timeElapsed = 0f;
            managerInstance.startSpeedingUp = false;
        }
    }

}