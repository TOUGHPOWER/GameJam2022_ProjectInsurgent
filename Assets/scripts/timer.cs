using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] float timerMax = 100;
    [SerializeField] TextMeshProUGUI timerDisplay;
    private float time;
    public PlayableDirector dieTimeline;
    public GameObject dieScreenUI;

    private void Start()
    {
        time = timerMax;
        dieScreenUI.SetActive(false);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timerDisplay.text = time.ToString("F0");
        if (time <= 0)
            loseGame();
    }

    public void loseGame()
    {
        dieScreenUI.SetActive(true);

        dieTimeline.Play();

        Time.timeScale = 0;
    }
}
