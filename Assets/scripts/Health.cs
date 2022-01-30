using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Health : MonoBehaviour
{
    private int                     HP;
    [SerializeField] int            maxHP = 100;
    private Animator                animator;
    [SerializeField] GameObject     Drop;
    public Slider                   healthBar;
    [SerializeField] bool           isPlayer=false;
    public timer                    tempo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        HP = maxHP;
        updateBar();
    }

    public void modifyHP(int x)
    {
        HP += x;
        if (HP <= 0)
        {
            if (animator != null && !isPlayer)
                animator.SetTrigger("dead");
            else
                death();
        }

        if(HP > maxHP)
            HP = maxHP;

        if (x < 0 && animator != null)
            animator.SetTrigger("hurt");

        updateBar();
    }

    public void death()
    {
        if (!isPlayer)
        {
            if(Drop != null)
                Instantiate(Drop, transform);
            Destroy(gameObject);
        }
        else
        {
            tempo.loseGame();
        }
    }

    private void updateBar()
    {
        if(healthBar != null)
        {
            healthBar.maxValue = maxHP;
            healthBar.value = HP;
        }
            
    }

    public bool isDead()
    {
        return HP < 0 ? true : false;
    }
}
