using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    
    public GameObject shield;

    public movementcontrols player;

    public float delay = 1;

    public float start_x;
    public float end_x;

    bool spawn = true;

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            StartCoroutine(spawn_shield());
        }
    }
    IEnumerator spawn_shield()
    {
        spawn = false;
        yield return new WaitForSeconds(delay / (player.forwardSpeed / 4));
        int x = Random.Range(-1, 2) * 2;
        GameObject shield_clone = Instantiate(shield, new Vector3(x, 3.5f, transform.position.z), Quaternion.identity);
        shield_clone.SetActive(true);
        spawn = true;
    }
}
