using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class DeathZone : MonoBehaviour
{
    public PlayableDirector dieTimeline;
    public GameObject dieScreenUI;

    private void Start()
    {
        dieScreenUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            

            dieScreenUI.SetActive(true);

            
            dieTimeline.Play();

            Time.timeScale = 0;
        }
    }

    
}
