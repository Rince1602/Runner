using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour
{
    public int coinsCount;
    [SerializeField] private Text coins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            coins.text = coinsCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
