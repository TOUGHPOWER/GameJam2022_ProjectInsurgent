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
    public PlayableDirector         dieTimeline;
    public GameObject               dieScreenUI;

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
        if (!isPlayer)
        {
            Instantiate(Drop, transform);
            Destroy(gameObject);
        }
        else
        {
            dieScreenUI.SetActive(true);

            dieTimeline.Play();

            Time.timeScale = 0;
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
}
