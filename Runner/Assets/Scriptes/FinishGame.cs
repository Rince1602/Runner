using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishGame : MonoBehaviour
{
    private float playerScore;
    [SerializeField] private CoinsCount coinsCount;
    [SerializeField] private Timer currentTime;
    [SerializeField] private Text score;
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private GameObject _interface;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            victoryCanvas.SetActive(true);
            _interface.SetActive(false);
            playerScore = currentTime.currentTime * 100 + coinsCount.coinsCount * 100;
            score.text = playerScore.ToString();
        }
    }
}
