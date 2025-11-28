using UnityEngine;

public class movementcontrols : MonoBehaviour
{
    public movementcontrols player;
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int currentLane = 1;

    public float forwardSpeed = 4f;

    private Rigidbody rb;

    private float targetX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        targetX = transform.position.x;

        currentLane = Mathf.RoundToInt(transform.position.x / laneDistance) + 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {currentLane = Mathf.Max(0, currentLane - 1);
            targetX = (1 - currentLane) * laneDistance;}

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {currentLane = Mathf.Min(2, currentLane + 1);
            targetX = (1 - currentLane) * laneDistance;}
    }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, forwardSpeed);

        float newX = 0.8f * Mathf.Lerp(transform.position.x, targetX, Time.fixedDeltaTime * laneSwitchSpeed);

        rb.position = new Vector3(newX, rb.position.y, rb.position.z);
    }
}