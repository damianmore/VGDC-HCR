using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coin;

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
            StartCoroutine(spawn_coin());
        }
    }
    IEnumerator spawn_coin()
    {
        spawn = false;
        yield return new WaitForSeconds(delay / (player.forwardSpeed / 4));
        int x = Random.Range(-1, 2) * 2;
        GameObject coin_clone = Instantiate(coin, new Vector3(x, 3.15f, transform.position.z), Quaternion.identity);
        coin_clone.transform.Rotate(Vector3.up * 90f);
        coin_clone.SetActive(true);
        spawn = true;
    }
}
