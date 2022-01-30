using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField] Player_type[]      charcters;
    private Player_mov                  legs;
    private Player_Gun                  gun;
    [SerializeField] int characterIndex = 0;
    public Health Hp;

    private void Start()
    {
        legs = GetComponent<Player_mov>();
        gun = GetComponent<Player_Gun>();
        setParameters();
    }

    public void nextCharcater()
    {
        charcters[characterIndex].Sprites.SetActive(false);
        characterIndex++;
        if (characterIndex >= charcters.Length)
            characterIndex = 0;
        setParameters();
    }

    private void setParameters()
    {
        Hp = charcters[characterIndex].playerxHP;

        legs.speed = charcters[characterIndex].speed;
        legs.jumpMaxSpeed = charcters[characterIndex].maxJump;
        legs.chargjump = charcters[characterIndex].chargeJump;
        charcters[characterIndex].Sprites.SetActive(true);
        legs.animationController = charcters[characterIndex].Sprites.GetComponent<Animator>();

        gun.projectalie = charcters[characterIndex].projectalie;
        gun.gunPoint = charcters[characterIndex].gunPoint;
        gun.cooldown = charcters[characterIndex].cooldown;
        gun.animationController = charcters[characterIndex].Sprites.GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3") && gun.timer<=0.1)
            nextCharcater();
    }
}
