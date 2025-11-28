using UnityEngine;

public class slowdown : MonoBehaviour
{
    public float baseSpeed = 4f;
    public float slowMultiplier = 0.3f;
    public float slowDuration = 2f;

    private float currentMultiplier = 1f;
    private float slowTimer = 0f;
    private movementcontrols playerMovement;

    [SerializeField] private AudioSource crashSound;

    void Awake()
    {
        playerMovement = GameObject.FindFirstObjectByType<movementcontrols>();
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

        playerMovement.forwardSpeed = baseSpeed * currentMultiplier;
        //transform.position += new Vector3(0, 0, baseSpeed * currentMultiplier) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {         
            Debug.Log(other.gameObject.name);
            Debug.Log($"Player: {transform.position} | Cone: {other.gameObject.transform.position}");
            if(Mathf.Abs(transform.position.x - other.transform.position.x) > .5f) return;
            if (currentMultiplier == slowMultiplier) Debug.Log("Game Over");

            Destroy(other.gameObject);
            crashSound.Play();   
            currentMultiplier = slowMultiplier;
            slowTimer = slowDuration;
        }
    }
}