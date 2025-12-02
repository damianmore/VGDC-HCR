using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCar : MonoBehaviour
{
    public GameObject enemy;

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
            StartCoroutine(spawn_enemy());
        }
    }
    IEnumerator spawn_enemy()
    {
        spawn = false;
        yield return new WaitForSeconds(delay / (player.forwardSpeed / 4));
        int x = Random.Range(-1, 2) * 2;
        GameObject enemy_clone = Instantiate(enemy, new Vector3(x, 3.5f, transform.position.z), Quaternion.identity);
        enemy_clone.SetActive(true);
        spawn = true;
    }
}
