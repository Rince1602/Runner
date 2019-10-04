using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    private float startingTime = 60f;
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private GameObject _interface;

    [SerializeField] private Text timer;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timer.text = currentTime.ToString("0");

        if (currentTime <= 10)
            timer.color = Color.red;

        if (currentTime <= 0)
        {
            canvasLose.SetActive(true);
            _interface.SetActive(false);
        }
    }
}
