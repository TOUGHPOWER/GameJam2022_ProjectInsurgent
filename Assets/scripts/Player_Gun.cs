using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gun : MonoBehaviour
{
    public GameObject projectalie;
    public float cooldown=1;
    public float timer=0;
    private bool hasShoot=false;
    public Transform gunPoint;
    public Animator animationController;
    private bool inAnimation = false;

    private void Update()
    {
        if (hasShoot)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            hasShoot = false;
            inAnimation = false;
        }

        if (Input.GetButtonDown("Fire1") && !inAnimation && !hasShoot)
        {
            if (animationController != null)
            {
                inAnimation = true;
                animationController.SetTrigger("Shoot");
            }
                
            else
                shootProjectile();
        }
    }

    public void shootProjectile()
    {
        timer = cooldown;
        inAnimation = false;
        hasShoot = true;
        Instantiate(projectalie, gunPoint.position, gunPoint.rotation);
    }
}
