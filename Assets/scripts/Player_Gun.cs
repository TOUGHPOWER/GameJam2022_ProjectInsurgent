using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    public GameObject projectalie;
    public float cooldown=1;
    private float timer=0;
    private bool hasShoot=false;
    public Transform gunPoint;
    public Animator animationController;

    private void Update()
    {
        if (hasShoot)
            timer -= Time.deltaTime;

        if (timer <= 0)
            hasShoot = false;

        if (Input.GetButtonDown("Fire1"))
        {
            if (animationController != null)
                animationController.SetTrigger("Shoot");
            else
                shootProjectile();
        }
    }

    public void shootProjectile()
    {
        timer = cooldown;
        Instantiate(projectalie, gunPoint);
    }
}
