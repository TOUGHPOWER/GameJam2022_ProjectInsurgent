using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] GameObject screenMessage;


    private void Start()
    {
        screenMessage.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            screenMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        screenMessage.SetActive(false);
    }
}
