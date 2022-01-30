using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineIntro : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;


    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
        player.GetComponent<Player_mov>().enabled = false;
        player.GetComponent<Player_Gun>().enabled = false;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
        Debug.Log("i am disabled");
        player.GetComponent<Player_mov>().enabled = true;
        player.GetComponent<Player_Gun>().enabled = true;
    }
}
