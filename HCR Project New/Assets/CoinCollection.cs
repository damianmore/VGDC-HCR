using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

    public TextMeshProUGUI coinText;
    [SerializeField] private AudioSource hitCoinSound;

    private void OnTriggerEnter(Collider other)
    {
        if(Mathf.Abs(transform.position.x - other.transform.position.x) > .5f) return;
        if (other.gameObject.CompareTag("Coin"))
        {
            Coin ++;
            coinText.text = "Coins: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
            hitCoinSound.Play();
        }
    }
}
