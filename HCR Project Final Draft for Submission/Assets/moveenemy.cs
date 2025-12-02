using UnityEngine;

public class moveenemy : MonoBehaviour
{
    private movementcontrols playerMovement;
    void Awake()
    {
        playerMovement = GameObject.FindFirstObjectByType<movementcontrols>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, playerMovement.forwardSpeed) * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Destroy"))
         {
              Destroy(gameObject);
         }
    }
}
