using UnityEngine;

public class Move : MonoBehaviour
{
    public float baseSpeed = 4f;
    public float slowMultiplier = 0.3f;
    public float slowDuration = 2f;

    private float currentMultiplier = 1f;
    private float slowTimer = 0f;

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
        
        transform.position += new Vector3(0, 0, baseSpeed * currentMultiplier) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Debug.Log("Ghost hit — slowing down"); //TESTING GHOST OBJECT
            
            currentMultiplier = slowMultiplier;
            slowTimer = slowDuration;
        }
    }
}