using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
        }
    }


}
