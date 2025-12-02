using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

    public TextMeshProUGUI coinText;
    [SerializeField] private AudioSource hitCoinSound;

    private void OnTriggerStay(Collider col)
    {
        if (! col.CompareTag("Coin")) return;
        if(Mathf.Abs(transform.position.x - col.transform.position.x) > .5f) return;
        if (col.gameObject.CompareTag("Coin"))
        {
            Coin ++;
            coinText.text = "Coins: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(col.gameObject);
            hitCoinSound.Play();
        }
    }
}
