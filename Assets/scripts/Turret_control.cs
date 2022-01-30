using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_control : MonoBehaviour
{
    private GameObject player;
    private LineRenderer laser;
    private Transform target;
    [SerializeField] Transform laserPos;
    void Start()
    {
        player = FindObjectOfType<Player_controller>().gameObject;
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        laser.SetPosition(0, laserPos.position);
        laser.SetPosition(1, target.position);
    }
}
