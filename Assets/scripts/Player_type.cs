using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_type : MonoBehaviour
{
    public Health playerxHP;
    public int speed = 4;
    public int maxJump = 7;
    public bool chargeJump = false;
    public GameObject Sprites;

    public GameObject projectalie;
    public float cooldown = 1;
    public Transform gunPoint;


    public void shoot() 
    {
        GetComponentInParent<Player_Gun>().shootProjectile();
    }
}
