using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int                     HP;
    [SerializeField] int            maxHP = 100;
    private Animator                animator;
    [SerializeField] GameObject     Drop;
    public Slider                   healthBar;

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
            if (animator != null)
                animator.SetBool("dead", true);
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
        Instantiate(Drop, transform);
        Destroy(gameObject);
    }

    private void updateBar()
    {
        if(healthBar != null)
        {
            healthBar.maxValue = maxHP;
            healthBar.value = HP;
        }
            
    }
}
